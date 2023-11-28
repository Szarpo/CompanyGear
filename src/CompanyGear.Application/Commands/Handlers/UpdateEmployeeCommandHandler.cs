using CompanyGear.Application.Abstractions;
using CompanyGear.Application.DTO;
using CompanyGear.Application.Queries;
using CompanyGear.Core.Entities;
using CompanyGear.Core.Repositories;
using CompanyGear.Core.ValueObjects;

namespace CompanyGear.Application.Commands.Handlers;

public sealed class UpdateEmployeeCommandHandler : ICommandHandler<UpdateEmployeeCommand>
{
    private readonly IEmployeeRepository _employeeRepository;

    public UpdateEmployeeCommandHandler(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }
    public async Task HandleAsync(UpdateEmployeeCommand command)
    {
        var (id, firstName, lastName, employeeNumber, department) = command;
        var employee = await _employeeRepository.GetEmployeeById(id: id);
        employee.Update(
            firstName: new FirstName(firstName),
            lastName: new LastName(lastName),
            employeeNumber: new EmployeeNumber(employeeNumber),
            department: new Department(department)
            );

        await _employeeRepository.Update(employee);
    }

}