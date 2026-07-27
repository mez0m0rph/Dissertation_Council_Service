using DissCouncil.App.DTOs;
using DissCouncil.Domain.Entities;
using DissCouncil.Domain.Enums;
using DissCouncil.Persistence.Repositories;

namespace DissCouncil.App.Services;

public class DefenseService : IDefenseService
{
    private readonly IDefenseRepository _repo;
    private readonly IDissertationRepository _repoDisser;

    public DefenseService(IDefenseRepository repo,
        IDissertationRepository repoDisser)
    {
        _repo = repo;
        _repoDisser = repoDisser;
    }

    private DefenseDto MapToDto(Defense defense)
    {
        return new DefenseDto
        {
            Id = defense.Id,
            DissertationId = defense.DissertationId,
            StartTime = defense.StartTime,
            FinishTime = defense.FinishTime,
            CouncilMembersRequired = defense.CouncilMembersRequired,
            CouncilMembersPresent = defense.CouncilMembersPresent,
            VotesFor = defense.VotesFor,
            VotesAgainst = defense.VotesAgainst,
            InvalidBallots = defense.InvalidBallots,
            Status = defense.Status,
            DissertationTitle = defense.Dissertation?.Title
        };
    }

    public async Task<DefenseDto?> AddAsync(CreateDefenseDto dto)
    {
        var dissertation = await _repoDisser.GetByIdAsync(dto.DissertationId);

        if (dissertation is null) 
            return null;

        var defense = new Defense
        {
            DissertationId = dto.DissertationId,
            Dissertation = dissertation,
            StartTime = dto.StartTime,
            FinishTime = dto.FinishTime,
            CouncilMembersRequired = dto.CouncilMembersRequired,
            CouncilMembersPresent = dto.CouncilMembersPresent,
            VotesFor = dto.VotesFor,
            VotesAgainst = dto.VotesAgainst,
            InvalidBallots = dto.InvalidBallots,
            Status = DefenseStatus.Scheduled
        };

        await _repo.AddAsync(defense);

        return MapToDto(defense);
    }

    public async Task<DefenseDto?> GetByIdAsync(Guid id)
    {
        var defense = await _repo.GetByIdAsync(id);
        
        if (defense is null)
            return null;
        
        return MapToDto(defense);
    }

    public async Task<List<DefenseDto>> GetAllAsync()
    {
        var defenses = await _repo.GetAllAsync();

        return defenses
            .Select(d => MapToDto(d))
            .ToList();
    }

    public async Task<bool> UpdateAsync (Guid id, UpdateDefenseDto dto)
    {
        var defense = await _repo.GetByIdAsync(id);

        if (defense is null)
            return false;

        var updatedDefense = new Defense
        {
            Id = id,
            DissertationId = defense.DissertationId,
            StartTime = dto.StartTime,
            FinishTime = dto.FinishTime,
            CouncilMembersRequired = dto.CouncilMembersRequired,
            CouncilMembersPresent = dto.CouncilMembersPresent,
            VotesFor = dto.VotesFor,
            VotesAgainst = dto.VotesAgainst,
            InvalidBallots = dto.InvalidBallots,
            Status = defense.Status
        };

        await _repo.UpdateAsync(updatedDefense);
        return true;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var defense = await _repo.GetByIdAsync(id);

        if (defense is null)
            return false;

        await _repo.DeleteAsync(id);
        return true;
    }
}