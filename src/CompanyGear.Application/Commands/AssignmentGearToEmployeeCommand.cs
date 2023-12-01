using CompanyGear.Application.Abstractions;

namespace CompanyGear.Application.Commands;

public sealed record AssignmentGearToEmployeeCommand(Guid employeeId, Guid gearId) : ICommand;