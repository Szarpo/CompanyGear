using CompanyGear.Application.Abstractions;
using CompanyGear.Application.Commands;
using CompanyGear.Application.Commands.Handlers;
using Microsoft.AspNetCore.Mvc;

namespace CompanyGear.Api.Controllers;

[ApiController]
[Route("gear")]
public class GearController : ControllerBase
{
    private readonly ICommandHandler<CreateGearCommand> _createGear;

    public GearController(ICommandHandler<CreateGearCommand> createGear)
    {
        _createGear = createGear;
    }


    [HttpPost]
    public async Task<ActionResult> Create(CreateGearCommand command)
    {
        return NoContent();
    }

}