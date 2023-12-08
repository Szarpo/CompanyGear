using CompanyGear.Application.Commands;
using CompanyGear.Application.DTO;
using CompanyGear.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CompanyGear.Api.Controllers;

[ApiController]
[Route("relation")]
public class RelationController : ControllerBase
{

    private readonly IMediator _mediator;

    public RelationController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpPost] 
    public async Task<ActionResult> AddRelationGearWithEmployee(CreateRelationEmployeeWithGearCommand command)
    {
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<RelationDto>>> GetRelations([FromQuery] GetRelationsQuery query)
    {
        return Ok(await _mediator.Send(query));
    }

    [HttpDelete]
    public async Task<ActionResult> DeleteRelation([FromQuery] DeleteRelationCommand command)
    {
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpGet("relationId")]
    public async Task<ActionResult<RelationDto>> GetRelationById([FromQuery] GetRelationByIdQuery query) 
        => Ok(await _mediator.Send(query));

}