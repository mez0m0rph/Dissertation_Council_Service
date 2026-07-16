using System.ComponentModel.DataAnnotations;
using DissCouncil.Domain.Enums;

namespace DissCouncil.App.DTOs;

public class UpdateApplicantDto
{
    [Required]
    [MaxLength(200)]
    public required string FullName { get; set; }
    [Required]
    [MaxLength(300)]
    public required string Organization { get; set; }
    [EnumDataType(typeof(AcademicDegree))]
    public AcademicDegree Degree { get; set; }
}