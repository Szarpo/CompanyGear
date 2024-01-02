using CompanyGear.Application.Commands;
using CompanyGear.Application.DTO;
using CompanyGear.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CompanyGear.Api.Controllers;

[ApiController]
[Route("device")]
public class   DeviceController : ControllerBase
{
    private readonly IMediator _mediator;

    public DeviceController(IMediator mediator)
    {
        _mediator = mediator;
    }


    [HttpPost]
    [SwaggerOperation("Add new device")]
    [Authorize(policy: "is-admin")]
    public async Task<ActionResult> Create([FromBody] CreateDeviceCommand command)
    {
      
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpGet]
    [SwaggerOperation("Get all devices")]
    [Authorize(policy: "is-admin")]
    public  async Task<ActionResult<IEnumerable<DeviceDto>>> GetDevices([FromQuery] GetDevicesQuery query)
    {
        return Ok(await _mediator.Send(query));
    }

    [HttpPut]
    [SwaggerOperation("Update device data")]

    public async Task<ActionResult> UpdateDevice([FromBody] UpdateDeviceCommand command)
    {
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [SwaggerOperation("Delete device")]

    public async Task<ActionResult> DeleteDevice([FromQuery] DeleteDeviceCommand command)
    {
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpGet("deviceId")]
    [SwaggerOperation("Get device by ID")]

    public async Task<ActionResult<DeviceDto>> GetById([FromQuery] GetDeviceByIdQuery query)
        => Ok(await _mediator.Send(query));

}