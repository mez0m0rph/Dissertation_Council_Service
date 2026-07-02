using DissCouncil.Domain.Enums;

namespace DissCouncil.Domain.Entities;

public class Dissertation
{
    public Guid Id { get; set; }
    public required string Title { get; set; }
    public required string SpecialtyCode { get; set; }
    public DissertationType Type { get; set; }
    public DissertationStatus Status { get; set; }
    public DateOnly ApplicationDate { get; set; }

}