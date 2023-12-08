using CompanyGear.Application.DTO;
using MediatR;

namespace CompanyGear.Application.Queries;

public record GetGearsQuery : IRequest<IEnumerable<GearDto>>;
