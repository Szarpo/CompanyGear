using CompanyGear.Application.Abstractions;

namespace CompanyGear.Application.Commands;

public sealed record CreateEmployeeCommand(string FirstName, string LastName, int EmployeeNumber, string Department) : ICommand;