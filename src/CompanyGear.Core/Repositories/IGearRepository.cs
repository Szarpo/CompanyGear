using CompanyGear.Core.Entities;

namespace CompanyGear.Core.Repositories;

public interface IGearRepository
{
    Task Add(Gear gear);
}