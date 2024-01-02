using CompanyGear.Core.Repositories;
using MediatR;

namespace CompanyGear.Application.Commands.Handlers;

public class DeleteDeviceCommandHandler : IRequestHandler<DeleteDeviceCommand>
{
    private readonly IDeviceRepository _deviceRepository;

    public DeleteDeviceCommandHandler(IDeviceRepository deviceRepository)
    {
        _deviceRepository = deviceRepository;
    }


    public async Task Handle(DeleteDeviceCommand request, CancellationToken cancellationToken)
    {
        var gearToRemove = await _deviceRepository.GetById(request.GearId);
        await _deviceRepository.Delete(gearToRemove);
    }
}