using DissCouncil.Domain.Enums;

namespace DissCouncil.App.DTOs;

public class UpdateDissertationDto
{
    public required string Title { get; set; }
    public required string SpecialtyCode { get; set; }
    public DissertationType Type { get; set; }
}