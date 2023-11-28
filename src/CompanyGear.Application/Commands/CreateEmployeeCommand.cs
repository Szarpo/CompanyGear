using CompanyGear.Application.Abstractions;

namespace CompanyGear.Application.Commands;

public sealed record CreateEmployeeCommand(string FirstName, string LastName, string EmployeeNumber, string Department) : ICommand;