using DissCouncil.Domain.Enums;

namespace DissCouncil.Domain.Entities;

public class Defense
{
    public Guid Id { get; set; }
    public Guid DissertationId { get; set; }
    public Dissertation Dissertation { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime FinishTime { get; set; }
    public int CouncilMembersRequired { get; set; }
    public int CouncilMembersPresent { get; set; }
    public int VotesFor { get; set; }
    public int VotesAgainst { get; set; }
    public int InvalidBallots { get; set; }
    public DefenseStatus Status { get; set; }
}