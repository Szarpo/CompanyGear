using CompanyGear.Core.Entities;
using CompanyGear.Core.Exceptions;
using CompanyGear.Core.Repositories;
using MediatR;

namespace CompanyGear.Application.Commands.Handlers;

public sealed class CreateRelationEmployeeWithDeviceCommandHandler : IRequestHandler<CreateRelationEmployeeWithDeviceCommand>
{
    private readonly IRelationRepository _relationRepository;
    private readonly IEmployeeRepository _employeeRepository;

    public CreateRelationEmployeeWithDeviceCommandHandler(IRelationRepository relationRepository, IEmployeeRepository employeeRepository)
    {
        _relationRepository = relationRepository;
        _employeeRepository = employeeRepository;
    }


    public async Task Handle(CreateRelationEmployeeWithDeviceCommand request, CancellationToken cancellationToken)
    {

        var isExist = await _relationRepository.IsExistId(request.DeviceId);
        if (isExist)
        {
            throw new InvalidDeviceIdAssignedException(request.DeviceId);
        }
        
        var (employeeId, gearId) = request;
        var newRelation = Relation.CreateRelation(employeeId: request.EmployeeId, gearId: request.DeviceId);
        await _relationRepository.CreateRelationEmployeeWithDevice(newRelation);
    }
}