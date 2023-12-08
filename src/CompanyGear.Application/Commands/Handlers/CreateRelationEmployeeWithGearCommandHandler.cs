using CompanyGear.Core.Entities;
using CompanyGear.Core.Repositories;
using MediatR;

namespace CompanyGear.Application.Commands.Handlers;

public sealed class CreateRelationEmployeeWithGearCommandHandler : IRequestHandler<CreateRelationEmployeeWithGearCommand>
{
    private readonly IRelationRepository _relationRepository;

    public CreateRelationEmployeeWithGearCommandHandler(IRelationRepository relationRepository)
    {
        _relationRepository = relationRepository;
    }


    public async Task<Unit> Handle(CreateRelationEmployeeWithGearCommand request, CancellationToken cancellationToken)
    {
        var (employeeId, gearId) = request;
        var newRelation = Relation.CreateRelation(employeeId: request.EmployeeId, gearId: request.GearId);
        await _relationRepository.CreateRelationEmployeeToGear(newRelation);

            return Unit.Value;
    }
}