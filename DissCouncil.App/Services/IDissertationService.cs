using DissCouncil.Domain.Entities;
using DissCouncil.App.DTOs;
using DissCouncil.Domain.Enums;

namespace DissCouncil.App.Services;

public interface IDissertationService
{
    Task<DissertationDto?> AddAsync(CreateDissertationDto dto);
    Task<List<DissertationDto>> GetAllAsync(int page, int pageSize);
    Task<DissertationDto?> GetByIdAsync(Guid id);
    Task<bool> UpdateAsync(Guid id, UpdateDissertationDto dto);
    Task<bool> DeleteAsync(Guid id);
    Task<bool> ChangeStatusAsync(Guid id, DissertationStatus newStatus);
}