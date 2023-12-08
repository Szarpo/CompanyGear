using MediatR;

namespace CompanyGear.Application.Commands;

public sealed record DeleteGearCommand(Guid GearId) : IRequest;