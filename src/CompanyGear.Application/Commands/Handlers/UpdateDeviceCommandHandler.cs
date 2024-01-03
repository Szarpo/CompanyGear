using CompanyGear.Core.Enums;
using CompanyGear.Core.Exceptions;
using CompanyGear.Core.Repositories;
using CompanyGear.Core.ValueObjects;
using MediatR;

namespace CompanyGear.Application.Commands.Handlers;

public class UpdateDeviceCommandHandler : IRequestHandler<UpdateDeviceCommand>
{
    private readonly IDeviceRepository _deviceRepository;

    public UpdateDeviceCommandHandler(IDeviceRepository deviceRepository)
    {
        _deviceRepository = deviceRepository;
    }
    public async Task Handle(UpdateDeviceCommand request, CancellationToken cancellationToken)
    {
        var (gearId, typeOfDevice, model, serialNumber,uteNumber) = request;
        var isExist = await _deviceRepository.IsExist(gearId);
        
        if (!isExist)
        {
            throw new InvalidNotExistIdException(request.DeviceId);
        }
        
        var gear = await _deviceRepository.GetById(request.DeviceId);
        gear.Update(
            typeOfDevice: new TypeOfDevice((TypeOfDeviceEnum)typeOfDevice), 
            model: new Model(model), 
            serialNumber: new SerialNumber(serialNumber),
            uteNumber: new UteNumber(uteNumber)
            );

        await _deviceRepository.Update(gear);

    }
}