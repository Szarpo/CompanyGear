
using CompanyGear.Application.Abstractions;
using CompanyGear.Application.DTO;
using CompanyGear.Application.Queries;
using Microsoft.EntityFrameworkCore;

namespace CompanyGear.Infrastructure.DAL.Handlers;

internal sealed class GetEmployeeByIdQueryHandler : IQueryHandler<GetEmployeeByIdQuery, EmployeeDto>
{

    private readonly CompanyGearDbContext _dbContext;

    public GetEmployeeByIdQueryHandler(CompanyGearDbContext dbContext) => _dbContext = dbContext;


    public async Task<EmployeeDto> HandleASync(GetEmployeeByIdQuery query)
    {

        var employee = await _dbContext.Employees.AsNoTracking().SingleOrDefaultAsync(x => x.Id == query.EmployeeId);
        return employee.AsDto();
    }
}