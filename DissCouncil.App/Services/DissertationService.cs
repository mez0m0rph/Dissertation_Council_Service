using DissCouncil.Domain.Entities;
using DissCouncil.Persistence.Repositories;

namespace DissCouncil.App.Services;

public class DissertationService : IDissertationService
{
    private readonly IDissertationRepository _repo;

    public DissertationService(IDissertationRepository repo)
    {
        _repo = repo;
    }

    public async Task AddAsync(Dissertation dissertation)
    {
        await _repo.AddAsync(dissertation);
    }
}