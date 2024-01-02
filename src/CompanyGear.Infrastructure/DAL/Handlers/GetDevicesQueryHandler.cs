using CompanyGear.Application.DTO;
using CompanyGear.Application.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CompanyGear.Infrastructure.DAL.Handlers;

internal sealed class GetDevicesQueryHandler : IRequestHandler<GetDevicesQuery, IEnumerable<DeviceDto>>
{
    private readonly CompanyDeviceDbContext _dbContext;

    public GetDevicesQueryHandler(CompanyDeviceDbContext dbContext) => _dbContext = dbContext;
    
    public async Task<IEnumerable<DeviceDto>> Handle(GetDevicesQuery request, CancellationToken cancellationToken) => await _dbContext.Devices.AsNoTracking().Select(x => x.DeviceAsDto()).ToListAsync(cancellationToken: cancellationToken);
}