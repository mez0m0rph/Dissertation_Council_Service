using DissCouncil.Domain.Entities;

namespace DissCouncil.Persistence.Repositories;

public interface IDissertationRepository
{
    Task AddAsync(Dissertation dissertation);
    Task<List<Dissertation>> GetAllAsync();
    Task<Dissertation?> GetByIdAsync(Guid id);
    Task UpdateAsync(Dissertation updatedDis);
    Task<bool> DeleteAsync(Guid id);
}