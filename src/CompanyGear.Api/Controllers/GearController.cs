using CompanyGear.Application.Abstractions;
using CompanyGear.Application.Commands;
using CompanyGear.Application.Commands.Handlers;
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

    public GearController(ICommandHandler<CreateGearCommand> createGear, IQueryHandler<GetGearsQuery, IEnumerable<GearDto>> getGears, IQueryHandler<GetEmployeeWithGearQuery, GearWithEmployeeDto> getEmployeeWithGear, ICommandHandler<AssignmentGearToEmployeeCommand> assignmentGearToEmployee)
    {
        _createGear = createGear;
        _getGears = getGears;
        _getEmployeeWithGear = getEmployeeWithGear;
        _assignmentGearToEmployee = assignmentGearToEmployee;
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

    [HttpPut()]
    public async Task<ActionResult> AssignmentGearToEmployee([FromQuery] AssignmentGearToEmployeeCommand command)
    {
        await _assignmentGearToEmployee.HandleAsync(command);
        return NoContent();
    }

}