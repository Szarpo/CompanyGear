using CompanyGear.Application.Commands;
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
        return Ok();
    }

}