using CompanyGear.Core.Entities;
using CompanyGear.Core.Repositories;
using MediatR;

namespace CompanyGear.Application.Commands.Handlers;

public sealed class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand>
{
    private readonly IEmployeeRepository _employeeRepository;

    public CreateEmployeeCommandHandler(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }
    public async Task<Unit> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
    {
        var (firstName, lastName, employeeNumber, department) = request;
        var newEmployee = Employee.Create(firstName, lastName, employeeNumber, department);

        await _employeeRepository.Add(employee: newEmployee);
        
        return Unit.Value;
    }
}