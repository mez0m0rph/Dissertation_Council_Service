namespace DissCouncil.App.DTOs;

public class ConductDefenseDto
{
    public int CouncilMembersPresent { get; set; }
    public int VotesFor { get; set; }
    public int VotesAgainst { get; set; }
    public int InvalidBallots { get; set; }
}