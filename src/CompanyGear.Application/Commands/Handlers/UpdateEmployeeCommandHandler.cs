using CompanyGear.Core.Exceptions;
using CompanyGear.Core.Repositories;
using CompanyGear.Core.ValueObjects;
using MediatR;

namespace CompanyGear.Application.Commands.Handlers;

public sealed class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand>
{
    private readonly IEmployeeRepository _employeeRepository;

    public UpdateEmployeeCommandHandler(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    public async Task Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
    {
        var (id, firstName, lastName, employeeNumber, department) = request;
        var isExist = await _employeeRepository.IsExist(id: id);
        if (!isExist)
        {
            throw new InvalidNotExistIdException(message: id);
        }
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