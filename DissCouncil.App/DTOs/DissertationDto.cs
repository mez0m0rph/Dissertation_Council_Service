using DissCouncil.Domain.Enums;

namespace DissCouncil.App.DTOs;

public class DissertationDto
{
    public Guid Id { get; set; }
    public required string Title { get; set; }
    public DissertationType Type { get; set; }
    public DissertationStatus Status { get; set; }
    public DateOnly ApplicationDate { get; set; }
}