using DissCouncil.Domain.Entities;

namespace DissCouncil.Persistence.Repositories;

public interface IApplicantRepository
{
    Task AddAsync(Applicant applicant);
    Task<List<Applicant>> GetAllAsync();
    Task<Applicant?> GetByIdAsync(Guid id);
    Task UpdateAsync(Applicant updatedApplicant);
    Task<bool> DeleteAsync(Guid id);
}