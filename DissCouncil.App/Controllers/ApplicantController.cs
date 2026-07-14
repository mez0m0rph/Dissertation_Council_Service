using DissCouncil.App.DTOs;
using DissCouncil.App.Services;
using Microsoft.AspNetCore.Mvc;

namespace DissCouncil.App.Controllers;

[ApiController]
[Route("applicants")]
public class ApplicantController : ControllerBase
{
    private readonly IApplicantService _service;
    
    public ApplicantController(IApplicantService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateApplicantDto dto)
    {
        var applicant = await _service.AddAsync(dto);
        return Ok(applicant);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var applicant = await _service.GetByIdAsync(id);

        if (applicant is null) 
            return NotFound();

        return Ok(applicant);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var applicants = await _service.GetAllAsync();
        return Ok(applicants);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, UpdateApplicantDto dto)
    {
        var updatedApplicant = await _service.UpdateAsync(id, dto);

        if (!updatedApplicant)
            return NotFound();

        return NoContent();

    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var deletedApplicant = await _service.DeleteAsync(id);

        if (!deletedApplicant) 
            return NotFound();

        return NoContent();
    }
}