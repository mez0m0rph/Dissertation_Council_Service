using System.Reflection.Metadata;
using DissCouncil.Domain.Enums;

namespace DissCouncil.App.DTOs;

public class DefenseDto
{
    public Guid Id { get; set; }
    public Guid DissertationId { get; set; }
    public string? DissertationTitle { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime FinishTime { get; set; }
    public int CouncilMembersRequired { get; set; }
    public int CouncilMembersPresent { get; set; }
    public int VotesFor { get; set; }
    public int VotesAgainst { get; set; }
    public int InvalidBallots { get; set; }
    public DefenseStatus Status { get; set; }
}