using CompanyGear.Application.Commands;
using CompanyGear.Application.DTO;
using CompanyGear.Application.Security;
using MediatR;
using Microsoft.AspNetCore.Mvc;

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

    [HttpPost("sign-in")]
    public async Task<ActionResult<JwtDto>> Login([FromBody] SignInCommand command, ITokenStorage tokenStorage)
    {
        await _mediator.Send(command);
        var jwt = tokenStorage.Get();
        return jwt;
    }

    [HttpDelete("logout")]
    public async Task<ActionResult> Logout()
    {
        return NoContent();
    }

}