using CompanyGear.Application.Abstractions;
using CompanyGear.Core.Repositories;

namespace CompanyGear.Application.Commands.Handlers;

public class DeleteGearCommandHandler : ICommandHandler<DeleteGearCommand>
{
    private readonly IGearRepository _gearRepository;

    public DeleteGearCommandHandler(IGearRepository gearRepository)
    {
        _gearRepository = gearRepository;
    }
    public async Task HandleAsync(DeleteGearCommand command)
    {
        var gearToRemove = await _gearRepository.GetById(command.GearId);
        await _gearRepository.Delete(gearToRemove);
    }
}