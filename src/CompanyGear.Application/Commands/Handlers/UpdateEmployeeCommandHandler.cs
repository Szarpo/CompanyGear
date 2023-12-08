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
    
    public async Task<Unit> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
    {
        var (id, firstName, lastName, employeeNumber, department) = request;
        var employee = await _employeeRepository.GetEmployeeById(id: id);
        employee.Update(
            firstName: new FirstName(firstName),
            lastName: new LastName(lastName),
            employeeNumber: new EmployeeNumber(employeeNumber),
            department: new Department(department)
        );

        await _employeeRepository.Update(employee);
        return Unit.Value;
    }
}