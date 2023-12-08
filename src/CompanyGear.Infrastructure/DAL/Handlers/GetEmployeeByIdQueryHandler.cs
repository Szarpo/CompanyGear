using CompanyGear.Application.DTO;
using CompanyGear.Application.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CompanyGear.Infrastructure.DAL.Handlers;

internal sealed class GetEmployeeByIdQueryHandler : IRequestHandler<GetEmployeeByIdQuery, EmployeeDto>
{

    private readonly CompanyGearDbContext _dbContext;

    public GetEmployeeByIdQueryHandler(CompanyGearDbContext dbContext) => _dbContext = dbContext;

    public async Task<EmployeeDto> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
    {
        var employee = await _dbContext.Employees.AsNoTracking().SingleOrDefaultAsync(x => x.Id == request.EmployeeId, cancellationToken: cancellationToken);
        
        return employee.EmployeeAsDto();
    }
}