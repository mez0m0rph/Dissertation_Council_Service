using DissCouncil.App.DTOs;
using DissCouncil.Domain.Entities;

namespace DissCouncil.App.Services;

public interface IDefenseService
{
    Task<DefenseDto?> AddAsync(CreateDefenseDto dto);
    Task<DefenseDto?> GetByIdAsync(Guid id);
    Task<List<DefenseDto>> GetAllAsync();
    Task<bool> UpdateAsync (Guid id, UpdateDefenseDto dto);
    Task<bool> DeleteAsync(Guid id);
}