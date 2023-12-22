using CompanyGear.Application.Commands;
using CompanyGear.Application.DTO;
using CompanyGear.Application.Queries;
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

    [HttpGet]
    public async Task<ActionResult<UserDto>> GetAll([FromQuery] GetUsersQuery query) => Ok(await _mediator.Send(query));

    [HttpGet("userId")]
    public async Task<ActionResult<UserDto>> GetById([FromQuery] GetUserByIdQuery query) =>  Ok(await _mediator.Send(query));

}