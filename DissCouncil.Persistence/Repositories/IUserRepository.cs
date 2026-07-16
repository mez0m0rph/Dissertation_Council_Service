using DissCouncil.Domain.Entities;

namespace DissCouncil.Persistence.Repositories;

public interface IUserRepository
{
    Task AddAsync(User user);
    Task<User?> GetByUsernameAsync(string username);
}