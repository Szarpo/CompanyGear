using CompanyGear.Core.Repositories;
using MediatR;

namespace CompanyGear.Application.Commands.Handlers;

public class DeleteRelationCommandHandler : IRequestHandler<DeleteRelationCommand>
{
    private readonly IRelationRepository _repository;

    public DeleteRelationCommandHandler(IRelationRepository repository) =>_repository = repository;
    
    
    public async Task<Unit> Handle(DeleteRelationCommand request, CancellationToken cancellationToken)
    {

        var relation = await _repository.GetById(request.RelationId);
        await _repository.Delete(relation);
        
        return Unit.Value;
        
    }
}