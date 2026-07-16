using DissCouncil.App.DTOs;
using DissCouncil.Domain.Entities;
using DissCouncil.Domain.Enums;
using DissCouncil.Persistence.Repositories;

namespace DissCouncil.App.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _repo;

    public UserService(IUserRepository repo)
    {
        _repo = repo;
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
}