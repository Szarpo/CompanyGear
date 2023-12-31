using CompanyGear.Core.Entities;
using CompanyGear.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CompanyGear.Infrastructure.DAL.Repositories;

internal sealed class EmployeeRepository : IEmployeeRepository
{

    private readonly CompanyDeviceDbContext _dbContext;
    private readonly DbSet<Employee> _employees;

    public EmployeeRepository(CompanyDeviceDbContext dbContext)
    {
        _dbContext = dbContext;
        _employees = _dbContext.Employees;
    }

    public EmployeeRepository()
    {
    }
    
    public async Task Add(Employee employee)
    {
        await _employees.AddAsync(employee);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<Employee> GetEmployeeById(Guid id) => await _employees.FirstOrDefaultAsync(x => x.Id == id);
    

    public async Task Update(Employee employee)
    {
        _employees.Update(employee);
       await _dbContext.SaveChangesAsync();
    }
    

    public async Task Delete(Employee employee)
    {
        _dbContext.Remove(employee);
        await _dbContext.SaveChangesAsync();

    }

    public async Task<bool> IsExist(Guid id) => await _employees.AnyAsync(x => x.Id == id);
}