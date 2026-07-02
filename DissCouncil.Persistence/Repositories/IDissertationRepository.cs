using DissCouncil.Domain.Entities;

namespace DissCouncil.Persistence.Repositories;

public interface IDissertationRepository
{
    Task AddAsync(Dissertation dissertation);
    Task<List<Dissertation>> GetAllAsync();
}