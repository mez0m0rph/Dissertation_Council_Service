using DissCouncil.Domain.Enums;

namespace DissCouncil.Domain.Entities;

public class Applicant
{
    public Guid Id { get; set; }
    public required string FullName { get; set; }
    public required string Organization { get; set; }
    public AcademicDegree Degree { get; set; }
    public List<Dissertation> Dissertations { get; set; } = new();
}