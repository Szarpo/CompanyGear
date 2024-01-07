using CompanyGear.Application.Commands;
using CompanyGear.Application.DTO;
using CompanyGear.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

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

    [AllowAnonymous]
    [HttpPost("sign-up")]
    [SwaggerOperation("Create account")]
    public async Task<ActionResult> CreateUser(SignUpCommand command)
    {
        await _mediator.Send(command);
        return NoContent();
    }

    [Authorize(policy: "is-admin")]
    [HttpGet]
    [SwaggerOperation("Get all account")]
    public async Task<ActionResult<UserDto>> GetAll([FromQuery] GetUsersQuery query) => Ok(await _mediator.Send(query));

    [Authorize]
    [HttpPut]
    [SwaggerOperation("Change user data")]
    public async Task<ActionResult> UpdateUser([FromBody] UpdateUserCommand command)
    {
        if (string.IsNullOrWhiteSpace(User.Identity!.Name))
        {
            return NoContent();
        }
        
        await _mediator.Send(command);
        return NoContent();
    }
    
    [Authorize]
    [HttpDelete]
    [SwaggerOperation("Delete account")]
    public async Task<ActionResult> DeleteUser([FromQuery] DeleteUserCommand command)
    {
        if (string.IsNullOrWhiteSpace(User.Identity!.Name))
        {
            return NoContent();
        }

        var userId = Guid.Parse(User.Identity.Name);

        await _mediator.Send(command);
        return NoContent();
    }
    
    [Authorize(policy: "is-admin")]
    [HttpGet("userId")]
    [SwaggerOperation("Get account by ID")]
    public async Task<ActionResult<UserDto>> GetById([FromQuery] GetUserByIdQuery query) =>  Ok(await _mediator.Send(query));

    [Authorize(policy: "is-admin")]
    [HttpPut("changeRole")]    
    [SwaggerOperation("Change the user role")]
    public async Task<ActionResult> ChangeRole([FromBody] ChangeRoleCommand command)
    {
        await _mediator.Send(command);
        return NoContent();
    }

    [Authorize]
    [HttpGet("me")]
    [SwaggerOperation("Get authorized user data")]
    public async Task<ActionResult<UserDto>> Get()
    {

        if (string.IsNullOrWhiteSpace(User.Identity?.Name))
        {
            return NotFound();
        }
        
        var userId = Guid.Parse(User.Identity.Name);
        var user = await _mediator.Send(new GetUserByIdQuery(userId));

        return user;
    }

 
}