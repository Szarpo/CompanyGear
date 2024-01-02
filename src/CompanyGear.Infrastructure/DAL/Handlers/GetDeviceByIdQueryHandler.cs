using CompanyGear.Application.DTO;
using CompanyGear.Application.Queries;
using CompanyGear.Core.Exceptions;
using CompanyGear.Core.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CompanyGear.Infrastructure.DAL.Handlers;

internal sealed class GetDeviceByIdQueryHandler : IRequestHandler<GetDeviceByIdQuery, DeviceDto>
{
    private readonly CompanyDeviceDbContext _dbContext;
    private readonly IDeviceRepository _deviceRepository;

    public GetDeviceByIdQueryHandler(CompanyDeviceDbContext dbContext, IDeviceRepository deviceRepository)
    {
        _dbContext = dbContext;
        _deviceRepository = deviceRepository;
    }
    
    public async Task<DeviceDto> Handle(GetDeviceByIdQuery request, CancellationToken cancellationToken)
    {
        var isExist =await  _deviceRepository.IsExist(request.GearId);
        if (!isExist)
        {
            throw new InvalidNotExistIdException(id: request.GearId);
        }
        var gear = await _dbContext.Devices.AsNoTracking().FirstOrDefaultAsync(x => x.Id == request.GearId, cancellationToken: cancellationToken);

        return gear.DeviceAsDto();
    }
}