using CompanyGear.Application.Abstractions;

namespace CompanyGear.Application.Commands;

public sealed record CreateGearCommand(string TypeOfDevice, string Model, string SerialNumber, string UteNumber) : ICommand;