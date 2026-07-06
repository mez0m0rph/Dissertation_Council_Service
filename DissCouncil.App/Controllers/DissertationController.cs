using DissCouncil.App.Services;
using DissCouncil.Domain.Entities;
using DissCouncil.App.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace DissCouncil.App.Controllers;

[ApiController]
[Route("dissertations")]
public class DissertationController : ControllerBase
{
    private readonly IDissertationService _service;

    public DissertationController(IDissertationService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateDissertationDto dto)
    {
        var created = await _service.AddAsync(dto);
        return Ok(created);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var dissertations = await _service.GetAllAsync();
        return Ok(dissertations);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var dissertation = await _service.GetByIdAsync(id);

        if(dissertation == null) 
            return NotFound();

        return Ok(dissertation);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, UpdateDissertationDto dto)
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
}