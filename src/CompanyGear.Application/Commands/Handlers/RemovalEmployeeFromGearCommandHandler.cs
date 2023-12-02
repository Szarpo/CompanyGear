using CompanyGear.Application.Abstractions;
using CompanyGear.Core.Repositories;

namespace CompanyGear.Application.Commands.Handlers;

public class RemovalEmployeeFromGearCommandHandler : ICommandHandler<RemovalEmployeeFromGearCommand>
{
    private readonly IGearRepository _gearRepository;

    public RemovalEmployeeFromGearCommandHandler(IGearRepository gearRepository)
    {
        _gearRepository = gearRepository;
    }
    
    public async Task HandleAsync(RemovalEmployeeFromGearCommand command)
    {
        var gearId = command.gearId;
        var zeroGuidEmployee = new Guid("00000000-0000-0000-0000-000000000000");
        var gear = await _gearRepository.GetById(gearId);
        gear.RemovalEmployeeFromGear(zeroGuidEmployee);
        await _gearRepository.RemovalEmployeeFromGear(gear);

    }
}