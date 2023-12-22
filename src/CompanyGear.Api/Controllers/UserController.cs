using CompanyGear.Application.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CompanyGear.Api.Controllers;

[ApiController]
[Route("user")]
public class UserController : ControllerBase
{

    private readonly IMediator _mediator;

    public UserController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<ActionResult> CreateUser(SingUpCommand command)
    {
        await _mediator.Send(command);
        return NoContent();
    }

}