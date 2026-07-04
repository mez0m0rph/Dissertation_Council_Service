using DissCouncil.App.Services;
using DissCouncil.Domain.Entities;
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
    public async Task<IActionResult> Create(Dissertation dissertation)
    {
        await _service.AddAsync(dissertation);
        return Ok(dissertation);
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
    public async Task<IActionResult> Update(Guid id, Dissertation updatedDis)
    {
        var existing = await _service.GetByIdAsync(id);
        if (existing is null) 
            return NotFound();

        updatedDis.Id = id;
        await _service.UpdateAsync(updatedDis);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _service.DeleteAsync(id);
        return Ok();
    }
}