using System.Reflection.Metadata;
using CompanyGear.Application.DTO;
using CompanyGear.Core.Entities;
using CompanyGear.Core.Repositories;
using CompanyGear.Infrastructure.DAL.Handlers;
using Microsoft.EntityFrameworkCore;

namespace CompanyGear.Infrastructure.DAL.Repositories;

internal sealed class EmployeeRepository : IEmployeeRepository
{

    private readonly CompanyGearDbContext _dbContext;
    private readonly DbSet<Employee> _employees;

    public EmployeeRepository(CompanyGearDbContext dbContext)
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
}