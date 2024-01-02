using CompanyGear.Application.DTO;
using CompanyGear.Application.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CompanyGear.Infrastructure.DAL.Handlers;

internal sealed class GetEmployeesQueryHandler : IRequestHandler<GetEmployeesQuery, IEnumerable<EmployeeDto>>
{

    private readonly CompanyDeviceDbContext _dbContext;

    public GetEmployeesQueryHandler(CompanyDeviceDbContext dbContext) => _dbContext = dbContext;

    public async Task<IEnumerable<EmployeeDto>> Handle(GetEmployeesQuery request, CancellationToken cancellationToken)
    =>  await _dbContext.Employees.AsNoTracking().Select(x=> x.EmployeeAsDto()).ToListAsync(cancellationToken: cancellationToken);
}