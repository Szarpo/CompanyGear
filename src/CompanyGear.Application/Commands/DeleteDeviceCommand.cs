using MediatR;

namespace CompanyGear.Application.Commands;

public sealed record DeleteDeviceCommand(Guid DeviceId) : IRequest;