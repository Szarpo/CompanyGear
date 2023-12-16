using MediatR;

namespace CompanyGear.Application.Commands;

public sealed record UpdateGearCommand(Guid GearId, int TypeOfDevice, string Model, string SerialNumber, string UteNumber) : IRequest;