using DissCouncil.App.Services;
using DissCouncil.App.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace DissCouncil.App.Controllers;

[ApiController]
[Route("dissertations")]
[Authorize]
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
        
        if (created is null)
            return BadRequest("Applicant was not found");
            
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
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var deleted = await _service.DeleteAsync(id);

        if (!deleted) 
            return NotFound();

        return NoContent();
    }
}