using CompanyGear.Core.Entities;

namespace CompanyGear.Core.Repositories;

public interface IGearRepository
{
    Task Add(Gear gear);
    Task<Gear> GetById(Guid id);
    Task Delete(Gear gear);
}