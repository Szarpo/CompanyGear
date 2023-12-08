using MediatR;

namespace CompanyGear.Application.Commands;

public record DeleteRelationCommand(Guid RelationId) : IRequest;