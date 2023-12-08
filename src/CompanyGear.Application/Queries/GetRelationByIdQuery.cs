using CompanyGear.Application.DTO;
using MediatR;

namespace CompanyGear.Application.Queries;

public record GetRelationByIdQuery(Guid RelationId) : IRequest<RelationDto>;