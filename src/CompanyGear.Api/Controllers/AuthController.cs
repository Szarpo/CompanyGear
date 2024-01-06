using CompanyGear.Application.Commands;
using CompanyGear.Application.DTO;
using CompanyGear.Application.Security;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CompanyGear.Api.Controllers;

[ApiController]
[Route("auth")]
public class AuthController : ControllerBase
{
    private readonly IMediator _mediator;

    public AuthController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [AllowAnonymous]
    [HttpPost("sign-in")]
    [SwaggerOperation("Logging into the application")]
    public async Task<ActionResult<JwtDto>> Login([FromBody] SignInCommand command, ITokenStorage tokenStorage)
    {
        await _mediator.Send(command);
        var jwt = tokenStorage.Get();
        return jwt;
    }

    [HttpDelete("logout")]
    [SwaggerOperation("Revoke token")]
    public async Task<ActionResult> Logout(SignOutCommand command)
    {
        await _mediator.Send(command);
        return Ok();
    }

}