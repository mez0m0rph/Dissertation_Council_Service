namespace DissCouncil.App.DTOs;

public class UpdateDefenseDto
{
    public DateTime StartTime { get; set; }
    public DateTime FinishTime { get; set; }
    public int CouncilMembersRequired { get; set; }
    public int CouncilMembersPresent { get; set; }
    public int VotesFor { get; set; }
    public int VotesAgainst { get; set; }
    public int InvalidBallots { get; set; }
}