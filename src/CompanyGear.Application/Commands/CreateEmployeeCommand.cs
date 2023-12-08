using MediatR;

namespace CompanyGear.Application.Commands;

public sealed record CreateEmployeeCommand(string FirstName, string LastName, string EmployeeNumber, string Department) : IRequest;