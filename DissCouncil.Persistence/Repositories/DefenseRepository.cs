using DissCouncil.Domain.Entities;
using DissCouncil.Persistence;
using Microsoft.EntityFrameworkCore;

namespace DissCouncil.Persistence.Repositories;

public class DefenseRepository : IDefenseRepository
{
    private readonly AppDbContext _context;

    public DefenseRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Defense defense)
    {
        await _context.Defenses.AddAsync(defense);

        await _context.SaveChangesAsync();
    }

    public async Task<Defense?> GetByIdAsync(Guid id)
    {
        return await _context.Defenses
            .AsNoTracking()
            .Include(d => d.Dissertation)
            .FirstOrDefaultAsync(d => d.Id == id);
    }

    public async Task<List<Defense>> GetAllAsync(int page, int pageSize)
    {
        return await _context.Defenses
            .AsNoTracking()
            .Include(d => d.Dissertation)
            .OrderBy(d => d.Id)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
    }

    public async Task UpdateAsync(Defense defense)
    {
        _context.Defenses.Update(defense);

        await _context.SaveChangesAsync();
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var defense = await _context.Defenses.FirstOrDefaultAsync(d => d.Id == id);

        if (defense is null)
            return false;
            
        _context.Defenses.Remove(defense);

        await _context.SaveChangesAsync();
        
        return true;
    }
}