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
}