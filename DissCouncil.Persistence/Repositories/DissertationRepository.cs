using DissCouncil.Domain.Entities;

namespace DissCouncil.Persistence.Repositories;

public class DissertationRepository : IDissertationRepository
{
    private readonly AppDbContext _context;

    public DissertationRepository(AppDbContext context)
    {
        _context = context;
    } 

    public async Task AddAsync(Dissertation dissertation)
    {
        _context.Dissertations.Add(dissertation);
        await _context.SaveChangesAsync();
    }
}