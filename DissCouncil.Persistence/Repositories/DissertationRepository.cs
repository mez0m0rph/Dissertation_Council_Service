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
            .ToListAsync();
    }

    public async Task<Dissertation?> GetByIdAsync(Guid id)
    {
        return await _context.Dissertations
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<bool> UpdateAsync(Guid id, Dissertation updatedDis)
    {
        var dissertation = await _context.Dissertations
            .FirstOrDefaultAsync(x => x.Id == id);

        if (dissertation is null)
            return false;

        dissertation.Title = updatedDis.Title;
        dissertation.SpecialtyCode = updatedDis.SpecialtyCode;
        dissertation.Type = updatedDis.Type;
        dissertation.Status = updatedDis.Status;
        dissertation.ApplicationDate = updatedDis.ApplicationDate;
        
        await _context.SaveChangesAsync();
        return true;
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