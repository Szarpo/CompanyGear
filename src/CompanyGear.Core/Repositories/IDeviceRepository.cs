using CompanyGear.Core.Entities;

namespace CompanyGear.Core.Repositories;

public interface IDeviceRepository
{
    Task Add(Device device);
    Task<Device> GetById(Guid id);
    Task Update(Device device);
    Task Delete(Device device);
    Task<bool> IsExist(Guid id);
}