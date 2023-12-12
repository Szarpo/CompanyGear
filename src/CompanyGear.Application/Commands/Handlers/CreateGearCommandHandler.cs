using CompanyGear.Core.Entities;
using CompanyGear.Core.Repositories;
using CompanyGear.Core.ValueObjects;
using MediatR;

namespace CompanyGear.Application.Commands.Handlers;

public sealed class CreateGearCommandHandler : IRequestHandler<CreateGearCommand>
{
    private readonly IGearRepository _repository;

    public CreateGearCommandHandler(IGearRepository repository)
    {
        _repository = repository;
    }

    public async Task<Unit> Handle(CreateGearCommand request, CancellationToken cancellationToken)
    {
        var (typeOfDevice, model, serialNumber, uteNumber) = request;
        var newGear = Gear.Create(new TypeOfDevice(typeOfDevice), model, serialNumber, uteNumber);
        await _repository.Add(newGear);
        return Unit.Value;
        
    }
}