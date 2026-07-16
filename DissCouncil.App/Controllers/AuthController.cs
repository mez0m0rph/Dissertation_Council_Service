using Microsoft.AspNetCore.Mvc;
using DissCouncil.App.Services;
using DissCouncil.App.DTOs;

namespace DissCouncil.App.Controllers;

[ApiController]
[Route("auth")]
public class AuthController : ControllerBase
{
    private readonly IUserService _service;
    public AuthController(IUserService service)
    {
        _service = service;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterDto dto)
    {
        var registration = await _service.RegisterAsync(dto);
        
        if (!registration)
            return BadRequest("Username is already taken");

        return Ok("Registered");
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginDto dto)
    {
        var token = await _service.LoginAsync(dto);

        if (token is null)
            return Unauthorized("Wrong login or password");

        return Ok(token);
    }
}