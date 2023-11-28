using CompanyGear.Core.Entities;
using CompanyGear.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CompanyGear.Infrastructure.DAL.Repositories;

internal sealed class GearRepository : IGearRepository
{
    private readonly CompanyGearDbContext _dbContext;
    private readonly DbSet<Gear> _gears;

    public GearRepository(CompanyGearDbContext dbContext)
    {
        _dbContext = dbContext;
        _gears = _dbContext.Gears;
    }
    
    public GearRepository() {}
    
    public async Task Add(Gear gear)
    {
        await _gears.AddAsync(gear);
        await _dbContext.SaveChangesAsync();
    }
}