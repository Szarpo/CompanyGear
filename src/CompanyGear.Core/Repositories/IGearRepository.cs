using CompanyGear.Core.Entities;

namespace CompanyGear.Core.Repositories;

public interface IGearRepository
{
    Task Add(Gear gear);
    Task<Gear> GetById(Guid id);
    Task AssignmentGearToEmployee(Gear gear);
    Task RemovalEmployeeFromGear(Gear gear);
    Task Delete(Gear gear);
}