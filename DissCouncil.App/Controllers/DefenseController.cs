using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using DissCouncil.App.Services;
using DissCouncil.App.DTOs;

namespace DissCouncil.App.Controllers;

[ApiController]
[Route("defenses")]
[Authorize]
public class DefenseController : ControllerBase
{
    private readonly IDefenseService _service;
    public DefenseController(IDefenseService service)
    {
        _service = service;
    }

    [HttpPost]    
    public async Task<IActionResult> Create(CreateDefenseDto dto)
    {
        var created = await _service.AddAsync(dto);

        if (created is null)
            return BadRequest("Dissertation was not found");

        return Ok(created);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var defense = await _service.GetByIdAsync(id);

        if (defense is null)
            return NotFound();

        return Ok(defense);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(int page = 1, int pageSize = 20)
    {
        var defenses = await _service.GetAllAsync(page, pageSize);

        return Ok(defenses);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, UpdateDefenseDto dto)
    {
        var updated = await _service.UpdateAsync(id, dto);

        if (!updated) 
            return NotFound();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var deleted = await _service.DeleteAsync(id);

        if (!deleted)
            return NotFound();

        return NoContent();
    }

    [HttpPatch("{id}/conduct")]
    public async Task<IActionResult> Conduct(Guid id, ConductDefenseDto dto)
    {
        var defense = await _service.ConductAsync(id, dto);

        if (!defense)
            return BadRequest();
        
        return NoContent();
    }
}