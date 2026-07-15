using DissCouncil.Domain.Entities;
using DissCouncil.Domain.Enums;
using DissCouncil.Persistence.Repositories;
using DissCouncil.App.DTOs;

namespace DissCouncil.App.Services;

public class DissertationService : IDissertationService
{
    private readonly IDissertationRepository _repo;
    private readonly IApplicantRepository _repoApplicant;

    public DissertationService(IDissertationRepository repo,
        IApplicantRepository repoApplicant)
    {
        _repo = repo;
        _repoApplicant = repoApplicant;
    }

    private DissertationDto MapToDto(Dissertation dissertation)
    {
        return new DissertationDto
        {
            Id = dissertation.Id,
            Title = dissertation.Title,
            SpecialtyCode = dissertation.SpecialtyCode,
            Type = dissertation.Type,
            Status = dissertation.Status,
            ApplicationDate = dissertation.ApplicationDate,
            ApplicantName = dissertation.Applicant?.FullName
        };
    }

    public async Task<DissertationDto?> AddAsync(CreateDissertationDto dto)
    {
        var applicant = await _repoApplicant.GetByIdAsync(dto.ApplicantId);

        if (applicant is null)
            return null;

        var dissertation = new Dissertation
        {
            Title = dto.Title,
            SpecialtyCode = dto.SpecialtyCode,
            Type = dto.Type,
            ApplicantId = dto.ApplicantId,
            Status = DissertationStatus.Submitted,
            ApplicationDate = DateOnly.FromDateTime(DateTime.UtcNow)
        };
        await _repo.AddAsync(dissertation);
        return MapToDto(dissertation);

    }

    public async Task<List<DissertationDto>> GetAllAsync()
    {
        var dissertations = await _repo.GetAllAsync();

        return dissertations
            .Select(x => MapToDto(x))
            .ToList();
    }

    public async Task<DissertationDto?> GetByIdAsync(Guid id)
    {
        var dissertation = await _repo.GetByIdAsync(id);
        
        if (dissertation is null)
            return null;

        return MapToDto(dissertation);
    }

    public async Task<bool> UpdateAsync(Guid id, UpdateDissertationDto dto)
    {
        var existing = await _repo.GetByIdAsync(id);

        if (existing is null) 
            return false;

        var dissertation = new Dissertation
        {
            Id = id,
            Title = dto.Title,
            SpecialtyCode = dto.SpecialtyCode,
            Type = dto.Type
        };

        await _repo.UpdateAsync(dissertation);
        return true;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        return await _repo.DeleteAsync(id);
    }
}