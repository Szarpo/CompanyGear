using CompanyGear.Core.Repositories;
using MediatR;

namespace CompanyGear.Application.Commands.Handlers;

public class ArchiveRelationCommandHandler : IRequestHandler<ArchiveRelationCommand>
{

    private readonly IRelationRepository _relationRepository;

    public ArchiveRelationCommandHandler(IRelationRepository relationRepository)
    {
        _relationRepository = relationRepository;
    }
    
    public async Task Handle(ArchiveRelationCommand request, CancellationToken cancellationToken)
    {
        var relationId = request.RelationId;
        var relation = await _relationRepository.GetById(id: relationId);
        relation.ArchiveRelation(relationStatus: 1);

        await _relationRepository.ArchiveRelation(relation);
    }
}