using CompanyGear.Core.Entities;
using CompanyGear.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CompanyGear.Infrastructure.DAL.Repositories;

internal sealed class UserRepository : IUserRepository
{
    private readonly CompanyDeviceDbContext _dbContext;
    private readonly DbSet<User> _users;

    public UserRepository(CompanyDeviceDbContext dbContext)
    {
        _dbContext = dbContext;
        _users = dbContext.Users;

    }

    public async Task SignUp(User user)
    {
        await _users.AddAsync(user);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<bool> LoginIsExist(string login) => await _users.AnyAsync(x => x.Login == login);
    public async Task<bool> UserExist(Guid userId) => await _users.AnyAsync(x => x.Id == userId);

    public async Task Update(User user)
    {
         _users.Update(user);
         await _dbContext.SaveChangesAsync();
    }

    public async Task<User> GetById(Guid userId) => await _users.FirstOrDefaultAsync(x => x.Id == userId);
    
    public async Task DeleteUser(User user)
    {
        _users.Remove(user);
        await _dbContext.SaveChangesAsync();
    }

    public async Task ChangeRole(User user)
    {
        _users.Update(user);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<User> GetByLogin(string login) => await _users.FirstOrDefaultAsync(x => x.Login == login);
}