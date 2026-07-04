using DissCouncil.Domain.Entities;

namespace DissCouncil.App.Services;

public interface IDissertationService
{
    Task AddAsync(Dissertation dissertation);
    Task<List<Dissertation>> GetAllAsync();
    Task<Dissertation?> GetByIdAsync(Guid id);
    Task<bool> UpdateAsync(Guid id, Dissertation updatedDis);
    Task<bool> DeleteAsync(Guid id);
}