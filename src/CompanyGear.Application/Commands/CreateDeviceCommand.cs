using CompanyGear.Core.Enums;
using MediatR;

namespace CompanyGear.Application.Commands;

public sealed record CreateDeviceCommand(TypeOfDeviceEnum TypeOfDevice, string Model, string SerialNumber, string UteNumber) : IRequest;