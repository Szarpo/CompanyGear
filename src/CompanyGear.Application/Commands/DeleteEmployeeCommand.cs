using CompanyGear.Application.Abstractions;

namespace CompanyGear.Application.Commands;

public sealed record DeleteEmployeeCommand(Guid EmployeeId) : ICommand
{
    
}