using System.Data.Common;
using DissCouncil.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DissCouncil.Persistence.Repositories;

public class ApplicantRepository : IApplicantRepository
{
    private readonly AppDbContext _context;

    public ApplicantRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Applicant applicant)
    {
        _context.Applicants.Add(applicant);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Applicant>> GetAllAsync()
    {
        return await _context.Applicants
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<Applicant?> GetByIdAsync(Guid id)
    {
        return await _context.Applicants
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task UpdateAsync(Applicant updatedApplicant)
    {
        _context.Applicants.Update(updatedApplicant);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var applicant = await _context.Applicants
            .FirstOrDefaultAsync(x => x.Id == id);

        if (applicant is null)
            return false;

        _context.Applicants.Remove(applicant);
        await _context.SaveChangesAsync();
        return true;
    }
}