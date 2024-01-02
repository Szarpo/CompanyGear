using CompanyGear.Application.Commands;
using CompanyGear.Application.DTO;
using CompanyGear.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CompanyGear.Api.Controllers;

[ApiController]
[Route("relation")]
[Authorize(policy: "is-admin")]
public class RelationController : ControllerBase
{

    private readonly IMediator _mediator;

    public RelationController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpPost] 
    [SwaggerOperation("Create relation: employee with device")]
    public async Task<ActionResult> AddRelationGearWithEmployee([FromBody] CreateRelationEmployeeWithDeviceCommand command)
    {
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpPut("archiveRelation")]
    [SwaggerOperation("Add relation to archive")]
    public async Task<ActionResult> ArchiveRelation([FromBody] ArchiveRelationCommand command)
    {
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpGet]
    [SwaggerOperation("Get all relations")]
    public async Task<ActionResult<IEnumerable<RelationDto>>> GetRelations([FromQuery] GetRelationsQuery query)
    {
        return Ok(await _mediator.Send(query));
    }

    [HttpDelete]
    [SwaggerOperation("Delete relation")]
    public async Task<ActionResult> DeleteRelation([FromQuery] DeleteRelationCommand command)
    {
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpGet("relationId")]
    [SwaggerOperation("Get relation by ID")]
    public async Task<ActionResult<RelationDto>> GetRelationById([FromQuery] GetRelationByIdQuery query) 
        => Ok(await _mediator.Send(query));

}