using CompanyGear.Application.Commands;
using CompanyGear.Application.DTO;
using CompanyGear.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CompanyGear.Api.Controllers;

[ApiController]
[Route("gear")]
public class GearController : ControllerBase
{
    private readonly IMediator _mediator;

    public GearController(IMediator mediator)
    {
        _mediator = mediator;
    }


    [HttpPost]
    public async Task<ActionResult> Create(CreateGearCommand command)
    {
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpGet]
    public  async Task<ActionResult<IEnumerable<GearDto>>> GetGears([FromQuery] GetGearsQuery query)
    {
        return Ok(await _mediator.Send(query));
    }

    [HttpDelete]
    public async Task<ActionResult> DeleteGear([FromQuery] DeleteGearCommand command)
    {
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpGet("gearId")]
    public async Task<ActionResult<GearDto>> GetById([FromQuery] GetGearByIdQuery query)
        => await _mediator.Send(query);

}