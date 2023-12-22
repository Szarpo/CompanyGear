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

    [HttpPut]
    public async Task<ActionResult> UpdateUser([FromBody] UpdateUserCommand command)
    {
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    public async Task<ActionResult> DeleteUser([FromQuery] DeleteUserCommand command)
    {
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpGet("userId")]
    public async Task<ActionResult<UserDto>> GetById([FromQuery] GetUserByIdQuery query) =>  Ok(await _mediator.Send(query));

    [HttpPut("changeRole")]
    public async Task<ActionResult> ChangeRole([FromBody] ChangeRoleCommand command)
    {
        await _mediator.Send(command);
        return NoContent();
    }


}