using DissCouncil.Domain.Entities;
using DissCouncil.App.DTOs;

namespace DissCouncil.App.Services;

public interface IApplicantService
{
    Task<ApplicantDto> AddAsync(CreateApplicantDto dto);
    Task<List<ApplicantDto>> GetAllAsync();
    Task<ApplicantDto?> GetByIdAsync(Guid id);
    Task<bool> UpdateAsync(Guid id, UpdateApplicantDto dto);
    Task<bool> DeleteAsync(Guid id);
}