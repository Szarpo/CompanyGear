using MediatR;

namespace CompanyGear.Application.Commands;

public sealed record UpdateDeviceCommand(Guid DeviceId, int TypeOfDevice, string Model, string SerialNumber, string UteNumber) : IRequest;