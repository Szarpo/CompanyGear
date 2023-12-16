using CompanyGear.Application.DTO;
using CompanyGear.Application.Queries;
using CompanyGear.Core.Exceptions;
using CompanyGear.Core.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CompanyGear.Infrastructure.DAL.Handlers;

internal sealed class GetEmployeeByIdQueryHandler : IRequestHandler<GetEmployeeByIdQuery, EmployeeDto>
{

    private readonly CompanyGearDbContext _dbContext;
    private readonly IEmployeeRepository _employeeRepository;

    public GetEmployeeByIdQueryHandler(CompanyGearDbContext dbContext, IEmployeeRepository employeeRepository)
    {
        _dbContext = dbContext;
        _employeeRepository = employeeRepository;
    }

    public async Task<EmployeeDto> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
    {
        var isExist = await _employeeRepository.IsExist(request.EmployeeId);
        if (!isExist)
        {
            throw new InvalidNotExistIdException(id: request.EmployeeId);
        }
        var employee = await _dbContext.Employees.AsNoTracking().SingleOrDefaultAsync(x => x.Id == request.EmployeeId, cancellationToken: cancellationToken);
        
        return employee.EmployeeAsDto();
    }
}