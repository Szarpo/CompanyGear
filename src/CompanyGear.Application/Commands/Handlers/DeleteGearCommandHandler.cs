using CompanyGear.Core.Repositories;
using MediatR;

namespace CompanyGear.Application.Commands.Handlers;

public class DeleteGearCommandHandler : IRequestHandler<DeleteGearCommand>
{
    private readonly IGearRepository _gearRepository;

    public DeleteGearCommandHandler(IGearRepository gearRepository)
    {
        _gearRepository = gearRepository;
    }


    public async Task Handle(DeleteGearCommand request, CancellationToken cancellationToken)
    {
        var gearToRemove = await _gearRepository.GetById(request.GearId);
        await _gearRepository.Delete(gearToRemove);
    }
}