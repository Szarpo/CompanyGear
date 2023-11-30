using CompanyGear.Application.Abstractions;

namespace CompanyGear.Application.Commands;

public sealed record CreateGearCommand(string Type, string Model, string SerialNumber, string UteNumber) : ICommand;