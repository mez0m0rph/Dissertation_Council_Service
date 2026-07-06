using DissCouncil.Domain.Entities;
using DissCouncil.App.DTOs;

namespace DissCouncil.App.Services;

public interface IDissertationService
{
    Task<DissertationDto> AddAsync(CreateDissertationDto dto);
    Task<List<DissertationDto>> GetAllAsync();
    Task<DissertationDto?> GetByIdAsync(Guid id);
    Task<bool> UpdateAsync(Guid id, UpdateDissertationDto dto);
    Task<bool> DeleteAsync(Guid id);
}