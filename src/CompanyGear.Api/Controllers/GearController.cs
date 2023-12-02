using CompanyGear.Application.Abstractions;
using CompanyGear.Application.Commands;
using CompanyGear.Application.DTO;
using CompanyGear.Application.Queries;
using Microsoft.AspNetCore.Mvc;

namespace CompanyGear.Api.Controllers;

[ApiController]
[Route("gear")]
public class GearController : ControllerBase
{
    private readonly ICommandHandler<CreateGearCommand> _createGear;
    private readonly IQueryHandler<GetGearsQuery, IEnumerable<GearDto>> _getGears;
    private readonly IQueryHandler<GetEmployeeWithGearQuery, GearWithEmployeeDto> _getEmployeeWithGear;
    private readonly ICommandHandler<AssignmentGearToEmployeeCommand> _assignmentGearToEmployee;
    private readonly ICommandHandler<RemovalEmployeeFromGearCommand> _removalEmployeeFromGear;
    private readonly ICommandHandler<DeleteGearCommand> _deleteGear;

    public GearController(ICommandHandler<CreateGearCommand> createGear, IQueryHandler<GetGearsQuery, IEnumerable<GearDto>> getGears, IQueryHandler<GetEmployeeWithGearQuery, GearWithEmployeeDto> getEmployeeWithGear, ICommandHandler<AssignmentGearToEmployeeCommand> assignmentGearToEmployee, ICommandHandler<RemovalEmployeeFromGearCommand> removalEmployeeFromGear, ICommandHandler<DeleteGearCommand> deleteGear)
    {
        _createGear = createGear;
        _getGears = getGears;
        _getEmployeeWithGear = getEmployeeWithGear;
        _assignmentGearToEmployee = assignmentGearToEmployee;
        _removalEmployeeFromGear = removalEmployeeFromGear;
        _deleteGear = deleteGear;
    }


    [HttpPost]
    public async Task<ActionResult> Create(CreateGearCommand command)
    {
        await _createGear.HandleAsync(command);
        return NoContent();
    }

    [HttpGet]
    public  async Task<ActionResult<IEnumerable<GearDto>>> GetGears([FromQuery] GetGearsQuery query)
    {
        return Ok(await _getGears.HandleASync(query));
    }

    [HttpGet("{employeeId}")]
    public async Task<ActionResult<GearWithEmployeeDto>> GetGearByEmployee(Guid employeeId)
    {
        return Ok(await _getEmployeeWithGear.HandleASync( new GetEmployeeWithGearQuery {EmployeeId = employeeId}));
    }

    [HttpPut("/assignmentGearToEmployee")]
    public async Task<ActionResult> AssignmentGearToEmployee([FromQuery] AssignmentGearToEmployeeCommand command)
    {
        await _assignmentGearToEmployee.HandleAsync(command);
        return NoContent();
    }

    [HttpPut("/removalEmployeeFromGear")]
    public async Task<ActionResult> RemovalEmployeeFromGear([FromQuery] RemovalEmployeeFromGearCommand command)
    {
        await _removalEmployeeFromGear.HandleAsync(command);
        return NoContent();
    }

    [HttpDelete]
    public async Task<ActionResult> DeleteGear([FromQuery] Guid gearId)
    {
        var command = new DeleteGearCommand(GearId: gearId);
        await _deleteGear.HandleAsync(command);
        return NoContent();
    }

}