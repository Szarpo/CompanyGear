using MediatR;

namespace CompanyGear.Application.Commands;

public sealed record UpdateEmployeeCommand(Guid Id, string FirstName, string LastName, string EmployeeNumber, string Department) : IRequest;

