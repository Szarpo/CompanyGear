using CompanyGear.Application.Commands;
using CompanyGear.Application.DTO;
using CompanyGear.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CompanyGear.Api.Controllers;

[ApiController]
[Route("gear")]
public class   GearController : ControllerBase
{
    private readonly IMediator _mediator;

    public GearController(IMediator mediator)
    {
        _mediator = mediator;
    }


    [HttpPost]
    [SwaggerOperation("Add new device")]

    public async Task<ActionResult> Create([FromBody] CreateGearCommand command)
    {
      
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpGet]
    [SwaggerOperation("Get all devices")]

    public  async Task<ActionResult<IEnumerable<GearDto>>> GetGears([FromQuery] GetGearsQuery query)
    {
        return Ok(await _mediator.Send(query));
    }

    [HttpPut]
    [SwaggerOperation("Update device data")]

    public async Task<ActionResult> UpdateGear([FromBody] UpdateGearCommand command)
    {
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [SwaggerOperation("Delete device")]

    public async Task<ActionResult> DeleteGear([FromQuery] DeleteGearCommand command)
    {
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpGet("gearId")]
    [SwaggerOperation("Get device by ID")]

    public async Task<ActionResult<GearDto>> GetById([FromQuery] GetGearByIdQuery query)
        => Ok(await _mediator.Send(query));

}