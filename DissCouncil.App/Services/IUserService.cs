using DissCouncil.App.DTOs;

namespace DissCouncil.App.Services;

public interface IUserService
{
    Task<bool> RegisterAsync(RegisterDto dto);
    Task<string?> LoginAsync(LoginDto dto);
}