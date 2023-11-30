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
    private readonly IQueryHandler<GetEmployeeWithGearQuery, EmployeeWithGearDto> _getEmployeeWithGear;

    public GearController(ICommandHandler<CreateGearCommand> createGear, IQueryHandler<GetGearsQuery, IEnumerable<GearDto>> getGears, IQueryHandler<GetEmployeeWithGearQuery, EmployeeWithGearDto> getEmployeeWithGear)
    {
        _createGear = createGear;
        _getGears = getGears;
        _getEmployeeWithGear = getEmployeeWithGear;
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
    public async Task<ActionResult<EmployeeWithGearDto>> GetGearByEmployee(Guid employeeId)
    {
        return Ok(await _getEmployeeWithGear.HandleASync( new GetEmployeeWithGearQuery {EmployeeId = employeeId}));
    }

}