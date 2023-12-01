using CompanyGear.Application.Abstractions;
using CompanyGear.Application.DTO;
using CompanyGear.Application.Queries;
using Microsoft.EntityFrameworkCore;

namespace CompanyGear.Infrastructure.DAL.Handlers;

internal sealed class GetEmployeeWithGearQueryHandler : IQueryHandler<GetEmployeeWithGearQuery, GearWithEmployeeDto>
{
    private readonly CompanyGearDbContext _dbContext;

    public GetEmployeeWithGearQueryHandler(CompanyGearDbContext dbContext) => _dbContext = dbContext;

    public async Task<GearWithEmployeeDto> HandleASync(GetEmployeeWithGearQuery query)
    {



        var result = await _dbContext.Gears.Include(x=> x.Employee).FirstOrDefaultAsync(x=> x.EmployeeId == query.EmployeeId);


        return result.GearWithEmployeeAsDto();

    }
}