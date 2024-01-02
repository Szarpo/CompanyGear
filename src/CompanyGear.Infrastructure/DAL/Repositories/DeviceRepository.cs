using CompanyGear.Core.Entities;
using CompanyGear.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CompanyGear.Infrastructure.DAL.Repositories;

internal sealed class DeviceRepository : IDeviceRepository
{
    private readonly CompanyDeviceDbContext _dbContext;
    private readonly DbSet<Device> _devices;

    public DeviceRepository(CompanyDeviceDbContext dbContext)
    {
        _dbContext = dbContext;
        _devices = _dbContext.Devices;
    }
    
    public DeviceRepository() {}
    
    public async Task Add(Device device)
    {
        await _devices.AddAsync(device);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<Device> GetById(Guid id) => await _devices.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
    
    public async Task Update(Device device)
    {
        _devices.Update(device);
        await _dbContext.SaveChangesAsync();
    }


    public async Task Delete(Device device)
    {
        _devices.Remove(device);
         await _dbContext.SaveChangesAsync();
    }

    public async Task<bool> IsExist(Guid id) => await _devices.AnyAsync(x => x.Id == id);
    
}