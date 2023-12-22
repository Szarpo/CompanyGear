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

    public async Task<Gear> GetById(Guid id) => await _gears.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
    
    public async Task Update(Gear gear)
    {
         _gears.Update(gear);
        await _dbContext.SaveChangesAsync();
    }


    public async Task Delete(Gear gear)
    {
         _gears.Remove(gear);
         await _dbContext.SaveChangesAsync();
    }

    public async Task<bool> IsExist(Guid id) => await _gears.AnyAsync(x => x.Id == id);
    
}