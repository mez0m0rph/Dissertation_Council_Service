using DissCouncil.Domain.Enums;

namespace DissCouncil.App.DTOs;

public class UpdateApplicantDto
{
    public required string FullName { get; set; }
    public required string Organization { get; set; }
    public AcademicDegree Degree { get; set; }
}