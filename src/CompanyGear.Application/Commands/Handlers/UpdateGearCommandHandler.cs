using CompanyGear.Core.Enums;
using CompanyGear.Core.Exceptions;
using CompanyGear.Core.Repositories;
using CompanyGear.Core.ValueObjects;
using MediatR;

namespace CompanyGear.Application.Commands.Handlers;

public class UpdateGearCommandHandler : IRequestHandler<UpdateGearCommand>
{
    private readonly IGearRepository _gearRepository;

    public UpdateGearCommandHandler(IGearRepository gearRepository)
    {
        _gearRepository = gearRepository;
    }
    public async Task Handle(UpdateGearCommand request, CancellationToken cancellationToken)
    {
        var (gearId, typeOfDevice, model, serialNumber,uteNumber) = request;
        var isExist = await _gearRepository.IsExist(gearId);
        
        if (!isExist)
        {
            throw new InvalidNotExistIdException(request.GearId);
        }
        
        var gear = await _gearRepository.GetById(request.GearId);
        gear.Update(
            typeOfDevice: new TypeOfDevice((TypeOfGearEnum)typeOfDevice), 
            model: new Model(model), 
            serialNumber: new SerialNumber(serialNumber),
            uteNumber: new UteNumber(uteNumber)
            );

        await _gearRepository.Update(gear);

    }
}