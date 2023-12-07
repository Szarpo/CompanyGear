using CompanyGear.Application.Abstractions;
using MediatR;

namespace CompanyGear.Application.Commands;

public sealed record CreateRelationEmployeeWithGearCommand(Guid EmployeeId, Guid GearId) : IRequest;