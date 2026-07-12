using System.Linq.Expressions;
using DissCouncil.App.DTOs;
using DissCouncil.Domain.Entities;
using DissCouncil.Persistence.Repositories;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.VisualBasic;

namespace DissCouncil.App.Services;

public class ApplicantService : IApplicantService
{
    private readonly IApplicantRepository _repo;

    public ApplicantService(IApplicantRepository repo)
    {
        _repo = repo;
    }

    private ApplicantDto MapToDto(Applicant applicant)
    {
        return new ApplicantDto
        {
            Id = applicant.Id,
            FullName = applicant.FullName,
            Organization = applicant.Organization,
            Degree = applicant.Degree
        };
    }


    public async Task<ApplicantDto> AddAsync(CreateApplicantDto dto)
    {
        var applicant = new Applicant
        {
            FullName = dto.FullName,
            Organization = dto.Organization,
            Degree = dto.Degree
        };

        await _repo.AddAsync(applicant);
        return MapToDto(applicant);
    }

    public async Task<List<ApplicantDto>> GetAllAsync()
    {
        var applicants = await _repo.GetAllAsync();

        return applicants
            .Select(x => MapToDto(x))
            .ToList();
    }

    public async Task<ApplicantDto?> GetByIdAsync(Guid id)
    {
        var applicant = await _repo.GetByIdAsync(id);

        if (applicant is null) 
            return null;
        
        return MapToDto(applicant);
    }

    public async Task<bool> UpdateAsync(Guid id, UpdateApplicantDto dto)
    {
        var existing = await _repo.GetByIdAsync(id);

        if (existing is null)
            return false;

        var applicant = new Applicant
        {
            Id = id,
            FullName = dto.FullName,
            Organization = dto.Organization,
            Degree = dto.Degree
        };

        await _repo.UpdateAsync(applicant);
        return true;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        return await _repo.DeleteAsync(id);   
    }
}