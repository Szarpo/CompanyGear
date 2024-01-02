using CompanyGear.Application.DTO;
using MediatR;

namespace CompanyGear.Application.Queries;

public record GetDevicesQuery : IRequest<IEnumerable<DeviceDto>>;
