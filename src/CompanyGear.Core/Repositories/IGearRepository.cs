using CompanyGear.Core.Entities;

namespace CompanyGear.Core.Repositories;

public interface IGearRepository
{
    Task Add(Gear gear);
    Task<Gear> GetById(Guid id);
    Task Update(Gear gear);
    Task Delete(Gear gear);
    Task<bool> IsExist(Guid id);
}