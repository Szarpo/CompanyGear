using CompanyGear.Application.DTO;
using MediatR;

namespace CompanyGear.Application.Queries;

public record GetRelationsQuery : IRequest<IEnumerable<RelationDto>>;
