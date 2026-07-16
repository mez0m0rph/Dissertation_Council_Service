using System.ComponentModel.DataAnnotations;
using DissCouncil.Domain.Enums;

namespace DissCouncil.App.DTOs;

public class UpdateDissertationDto
{
    [Required]
    [MaxLength(300)]
    public required string Title { get; set; }
    [Required]
    [MaxLength(20)]
    public required string SpecialtyCode { get; set; }
    [EnumDataType(typeof(DissertationType))]
    public DissertationType Type { get; set; }
}