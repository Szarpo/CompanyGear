using CompanyGear.Application.Abstractions;
using CompanyGear.Core.Entities;
using CompanyGear.Core.Repositories;
using CompanyGear.Core.ValueObjects;

namespace CompanyGear.Application.Commands.Handlers;

public sealed class CreateEmployeeCommandHandler : ICommandHandler<CreateEmployeeCommand>
{
    private readonly IEmployeeRepository _employeeRepository;

    public CreateEmployeeCommandHandler(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }
    public async Task HandleAsync(CreateEmployeeCommand command)
    {
        var (firstName, lastName, employeeNumber, department) = command;
        var newEmployee = Employee.Create(firstName, lastName, employeeNumber, department);

        await _employeeRepository.Add(employee: newEmployee);
    }
}