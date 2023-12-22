using CompanyGear.Core.Entities;
using CompanyGear.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CompanyGear.Infrastructure.DAL.Repositories;

internal sealed class UserRepository : IUserRepository
{
    private readonly CompanyGearDbContext _dbContext;
    private readonly DbSet<User> _users;

    public UserRepository(CompanyGearDbContext dbContext)
    {
        _dbContext = dbContext;
        _users = dbContext.Users;

    }

    public async Task SignUp(User user)
    {
        await _users.AddAsync(user);
        await _dbContext.SaveChangesAsync();
    }
}