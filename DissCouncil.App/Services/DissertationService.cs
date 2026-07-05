using DissCouncil.Domain.Entities;
using DissCouncil.Domain.Enums;
using DissCouncil.Persistence.Repositories;
using DissCouncil.App.DTOs;

namespace DissCouncil.App.Services;

public class DissertationService : IDissertationService
{
    private readonly IDissertationRepository _repo;

    public DissertationService(IDissertationRepository repo)
    {
        _repo = repo;
    }

    public async Task AddAsync(CreateDissertationDto dto)
    {
        var dissertation = new Dissertation
        {
            Title = dto.Title,
            SpecialtyCode = dto.SpecialtyCode,
            Type = dto.Type,
            Status = DissertationStatus.Submitted,
            ApplicationDate = DateOnly.FromDateTime(DateTime.UtcNow)
        };
        await _repo.AddAsync(dissertation);
    }

    public async Task<List<Dissertation>> GetAllAsync()
    {
        return await _repo.GetAllAsync();
    }

    public async Task<Dissertation?> GetByIdAsync(Guid id)
    {
        return await _repo.GetByIdAsync(id);
    }

    public async Task<bool> UpdateAsync(Guid id, UpdateDissertationDto dto)
    {
        var existing = _repo.GetByIdAsync(id);

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