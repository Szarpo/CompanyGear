using CompanyGear.Core.Entities;

namespace CompanyGear.Core.Repositories;

public interface IEmployeeRepository
{
    Task Add(Employee employee);
    
}