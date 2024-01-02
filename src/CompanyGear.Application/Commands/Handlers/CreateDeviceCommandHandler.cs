using CompanyGear.Core.Entities;
using CompanyGear.Core.Repositories;
using CompanyGear.Core.ValueObjects;
using MediatR;

namespace CompanyGear.Application.Commands.Handlers;

public sealed class CreateDeviceCommandHandler : IRequestHandler<CreateDeviceCommand>
{
    private readonly IDeviceRepository _repository;

    public CreateDeviceCommandHandler(IDeviceRepository repository)
    {
        _repository = repository;
    }


    public async Task Handle(CreateDeviceCommand request, CancellationToken cancellationToken)
    {
        var (typeOfDevice, model, serialNumber, uteNumber) = request;
        var newGear = Device.Create(new TypeOfDevice(typeOfDevice), model, serialNumber, uteNumber);
        await _repository.Add(newGear);
    }
}