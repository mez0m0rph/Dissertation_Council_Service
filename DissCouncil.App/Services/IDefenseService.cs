using DissCouncil.App.DTOs;

namespace DissCouncil.App.Services;

public interface IDefenseService
{
    Task<DefenseDto?> AddAsync(CreateDefenseDto dto);
    Task<DefenseDto?> GetByIdAsync(Guid id);
    Task<List<DefenseDto>> GetAllAsync(int page, int pageSize);
    Task<bool> UpdateAsync (Guid id, UpdateDefenseDto dto);
    Task<bool> DeleteAsync(Guid id);
    Task<bool> ConductAsync(Guid id, ConductDefenseDto dto);
}