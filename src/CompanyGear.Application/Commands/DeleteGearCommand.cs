using CompanyGear.Application.Abstractions;

namespace CompanyGear.Application.Commands;

public sealed record DeleteGearCommand(Guid GearId) : ICommand;