using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DissCouncil.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddApplicant : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ApplicantId",
                table: "Dissertations",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Applicants",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FullName = table.Column<string>(type: "text", nullable: false),
                    Organization = table.Column<string>(type: "text", nullable: false),
                    Degree = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Applicants", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dissertations_ApplicantId",
                table: "Dissertations",
                column: "ApplicantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dissertations_Applicants_ApplicantId",
                table: "Dissertations",
                column: "ApplicantId",
                principalTable: "Applicants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dissertations_Applicants_ApplicantId",
                table: "Dissertations");

            migrationBuilder.DropTable(
                name: "Applicants");

            migrationBuilder.DropIndex(
                name: "IX_Dissertations_ApplicantId",
                table: "Dissertations");

            migrationBuilder.DropColumn(
                name: "ApplicantId",
                table: "Dissertations");
        }
    }
}
