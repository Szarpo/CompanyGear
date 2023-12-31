using MediatR;

namespace CompanyGear.Application.Commands;

public sealed record CreateRelationEmployeeWithDeviceCommand(Guid EmployeeId, Guid DeviceId) : IRequest;