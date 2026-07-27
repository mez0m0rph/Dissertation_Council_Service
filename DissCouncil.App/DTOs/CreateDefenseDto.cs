using System.ComponentModel.DataAnnotations;

namespace DissCouncil.App.DTOs;

public class CreateDefenseDto
{
    [Required]
    public Guid DissertationId { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime FinishTime { get; set; }
    public int CouncilMembersRequired { get; set; }
}