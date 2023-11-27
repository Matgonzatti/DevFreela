using DevFreela.Core.Entities;

namespace DevFreela.Core.Repositories;

public interface IUserRepository
{
    Task<List<User>> GetAllAsync();
    Task<User> GetByIdAsync(Guid id);
    Task<Guid> AddAsync(User user);
    Task<User> GetUserByEmailAndPasswordAsync(string email, string hashPassword);
}
