using CompanyGear.Application.Abstractions;

namespace CompanyGear.Application.Commands;

public record RemovalEmployeeFromGearCommand(Guid gearId) : ICommand;