using DissCouncil.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace DissCouncil.App.DTOs;

public class ChangeStatusDto
{
    [Required]
    [EnumDataType(typeof(DissertationStatus))]
    public DissertationStatus NewStatus { get; set; }
}