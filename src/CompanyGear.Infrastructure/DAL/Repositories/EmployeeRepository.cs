using CompanyGear.Core.Entities;
using CompanyGear.Core.Repositories;

namespace CompanyGear.Infrastructure.DAL.Repositories;

public class EmployeeRepository : IEmployeeRepository
{


    public EmployeeRepository()
    {
    }
    
    public Task Add(Employee employee)
    {
        throw new NotImplementedException();
    }
}