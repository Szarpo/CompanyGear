using CompanyGear.Application.Abstractions;
using CompanyGear.Application.DTO;
using CompanyGear.Application.Queries;
using Microsoft.EntityFrameworkCore;

namespace CompanyGear.Infrastructure.DAL.Handlers;

internal sealed class GetEmployeesQueryHandler : IQueryHandler<GetEmployeesQuery, IEnumerable<EmployeeDto>>
{

    private readonly CompanyGearDbContext _dbContext;

    public GetEmployeesQueryHandler(CompanyGearDbContext dbContext) => _dbContext = dbContext;

    public async Task<IEnumerable<EmployeeDto>> HandleASync(GetEmployeesQuery query) =>
        await _dbContext.Employees.AsNoTracking().Select(x=> x.EmployeeAsDto()).ToListAsync();
}