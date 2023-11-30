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

    public GearController(ICommandHandler<CreateGearCommand> createGear, IQueryHandler<GetGearsQuery, IEnumerable<GearDto>> getGears)
    {
        _createGear = createGear;
        _getGears = getGears;
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

}