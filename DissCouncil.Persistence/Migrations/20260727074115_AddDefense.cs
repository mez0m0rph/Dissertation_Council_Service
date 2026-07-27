using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DissCouncil.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddDefense : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Defenses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DissertationId = table.Column<Guid>(type: "uuid", nullable: false),
                    StartTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    FinishTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CouncilMembersRequired = table.Column<int>(type: "integer", nullable: false),
                    CouncilMembersPresent = table.Column<int>(type: "integer", nullable: false),
                    VotesFor = table.Column<int>(type: "integer", nullable: false),
                    VotesAgainst = table.Column<int>(type: "integer", nullable: false),
                    InvalidBallots = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Defenses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Defenses_Dissertations_DissertationId",
                        column: x => x.DissertationId,
                        principalTable: "Dissertations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Defenses_DissertationId",
                table: "Defenses",
                column: "DissertationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Defenses");
        }
    }
}
