using DissCouncil.Domain.Entities;
using DissCouncil.App.DTOs;

namespace DissCouncil.App.Services;

public interface IDissertationService
{
    Task AddAsync(CreateDissertationDto dto);
    Task<List<Dissertation>> GetAllAsync();
    Task<Dissertation?> GetByIdAsync(Guid id);
    Task<bool> UpdateAsync(Guid id, UpdateDissertationDto dto);
    Task<bool> DeleteAsync(Guid id);
}