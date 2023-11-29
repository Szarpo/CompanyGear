using CompanyGear.Application.Abstractions;
using CompanyGear.Core.Entities;
using CompanyGear.Core.Repositories;

namespace CompanyGear.Application.Commands.Handlers;

public sealed class CreateGearCommandHandler : ICommandHandler<CreateGearCommand>
{
    private readonly IGearRepository _repository;

    public CreateGearCommandHandler(IGearRepository repository)
    {
        _repository = repository;
    }
    
    public async Task HandleAsync(CreateGearCommand command)
    {
        var (typeOfDevice, model, serialNumber, uteNumber) = command;
        var newGear = Gear.Create(typeOfDevice, model, serialNumber, uteNumber);
        await _repository.Add(newGear);
    }
}