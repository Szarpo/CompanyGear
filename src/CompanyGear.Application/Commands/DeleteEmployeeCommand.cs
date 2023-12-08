using MediatR;

namespace CompanyGear.Application.Commands;

public sealed record DeleteEmployeeCommand(Guid EmployeeId) : IRequest;
