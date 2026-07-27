using DissCouncil.Domain.Entities;

namespace DissCouncil.Persistence.Repositories;

public interface IDefenseRepository
{
    Task AddAsync(Defense defense);
    Task<Defense?> GetByIdAsync(Guid id);
    Task<List<Defense>> GetAllAsync(int page, int pageSize);
    Task UpdateAsync(Defense defense);
    Task<bool> DeleteAsync(Guid id);
}