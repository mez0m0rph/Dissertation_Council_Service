using DissCouncil.App.DTOs;
using DissCouncil.Domain.Entities;
using DissCouncil.Domain.Enums;
using DissCouncil.Persistence.Repositories;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace DissCouncil.App.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _repo;
    private readonly IConfiguration _config;

    public UserService(IUserRepository repo, IConfiguration config)
    {
        _repo = repo;
        _config = config;
    }

    private string GenerateToken(User user)
    {
        var claims = new []
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.Username),
            new Claim(ClaimTypes.Role, user.Role.ToString())
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes
            (_config["Jwt:Key"]!));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _config["Jwt:Issuer"],
            audience: _config["Jwt:Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddHours(1),
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);

    }

    public async Task<bool> RegisterAsync(RegisterDto dto)
    {
        var existingUser = await _repo.GetByUsernameAsync(dto.Username);

        if (existingUser is not null)
            return false;
        
        var passwordHashed = BCrypt.Net.BCrypt.HashPassword(dto.Password);

        var newUser = new User
        {
            Username = dto.Username,
            PasswordHash = passwordHashed,
            Role = UserRole.User
        };

        await _repo.AddAsync(newUser);

        return true;
    }

    public async Task<string?> LoginAsync(LoginDto dto)
    {
        var user = await _repo.GetByUsernameAsync(dto.Username);

        if (user is null)
            return null;

        if (!BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash))
            return null;

        return GenerateToken(user);
    }
}