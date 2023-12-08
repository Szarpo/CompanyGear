using CompanyGear.Application.DTO;
using MediatR;

namespace CompanyGear.Application.Queries;

public record GetGearByIdQuery(Guid GearId) : IRequest<GearDto>;