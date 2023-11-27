using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Infrastructure.Persistence.Repositories;

public class UserRepository : IUserRepository
{
    private readonly DevFreelaDbContext _dbContext;


    public UserRepository(DevFreelaDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<User>> GetAllAsync() => await _dbContext.Users.ToListAsync();

    public async Task<User> GetByIdAsync(Guid id) => await _dbContext.Users.SingleOrDefaultAsync(user => user.Id == id);

    public async Task<Guid> AddAsync(User user)
    {
        await _dbContext.Users.AddAsync(user);
        await _dbContext.SaveChangesAsync();

        return user.Id;
    }

    public async Task<User> GetUserByEmailAndPasswordAsync(string email, string hashPassword) => await _dbContext.Users.SingleOrDefaultAsync(user => user.Email == email && user.Password == hashPassword);
}
