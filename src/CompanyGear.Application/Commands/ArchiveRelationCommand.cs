using MediatR;

namespace CompanyGear.Application.Commands;

public sealed record ArchiveRelationCommand(Guid RelationId) : IRequest;