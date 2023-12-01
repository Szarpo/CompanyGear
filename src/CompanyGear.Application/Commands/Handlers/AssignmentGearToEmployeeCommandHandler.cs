using CompanyGear.Application.Abstractions;
using CompanyGear.Core.Repositories;

namespace CompanyGear.Application.Commands.Handlers;

public sealed class AssignmentGearToEmployeeCommandHandler : ICommandHandler<AssignmentGearToEmployeeCommand>
{
    private readonly IGearRepository _gearRepository;

    public AssignmentGearToEmployeeCommandHandler(IGearRepository gearRepository)
    {
        _gearRepository = gearRepository;
    }
    public async Task HandleAsync(AssignmentGearToEmployeeCommand command)
    {
        var (employeeId, gearId) = command;
        var gear = await _gearRepository.GetById(command.gearId);
        gear.AssignmentGearToEmployee(employeeId: command.employeeId);
        await _gearRepository.AssignmentGearToEmployee(gear);
    }
}