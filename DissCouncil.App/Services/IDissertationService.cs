using DissCouncil.Domain.Entities;

namespace DissCouncil.App.Services;

public interface IDissertationService
{
    Task AddAsync(Dissertation dissertation);
    Task<List<Dissertation>> GetAllAsync();
    Task<Dissertation?> GetByIdAsync(Guid id);
    Task UpdateAsync(Dissertation updatedDis);
}