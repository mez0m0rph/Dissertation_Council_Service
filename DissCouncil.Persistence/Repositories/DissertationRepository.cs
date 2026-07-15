using DissCouncil.Domain.Entities;
using Microsoft.EntityFrameworkCore;

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

    public async Task<List<Dissertation>> GetAllAsync()
    {
        return await _context.Dissertations
            .AsNoTracking()
            .Include(x => x.Applicant)
            .ToListAsync();
    }

    public async Task<Dissertation?> GetByIdAsync(Guid id)
    {
        return await _context.Dissertations
            .AsNoTracking()
            .Include(x => x.Applicant)
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task UpdateAsync(Dissertation updatedDis)
    {
        _context.Dissertations.Update(updatedDis);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var dissertation = await _context.Dissertations
            .FirstOrDefaultAsync(x => x.Id == id);

        if (dissertation is null)
            return false;
        
        _context.Dissertations.Remove(dissertation);
        await _context.SaveChangesAsync();
        return true;
    }
}