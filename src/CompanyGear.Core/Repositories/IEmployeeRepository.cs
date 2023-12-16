using CompanyGear.Core.Entities;


namespace CompanyGear.Core.Repositories;

public interface IEmployeeRepository
{
    Task Add(Employee employee);
    Task<Employee> GetEmployeeById(Guid id);
    Task Update(Employee employee);
    Task Delete(Employee employee);
    Task<bool> IsExist(Guid id);

}