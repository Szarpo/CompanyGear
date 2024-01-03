using CompanyGear.Application.DTO;
using MediatR;

namespace CompanyGear.Application.Queries;

public record GetDeviceByIdQuery(Guid DeviceId) : IRequest<DeviceDto>;