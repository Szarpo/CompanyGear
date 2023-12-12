using CompanyGear.Application.Commands;
using CompanyGear.Application.DTO;
using CompanyGear.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CompanyGear.Api.Controllers;


[ApiController]
[Route("employee")]
public class EmployeeController : ControllerBase
{
    private readonly IMediator _mediator;

    public EmployeeController(
        IMediator mediator) => _mediator = mediator;
    
    
    [HttpPost]
    public async Task<ActionResult> CreateEmployeeCommand(CreateEmployeeCommand command)
    { 
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<EmployeeDto>>> GetEmployees([FromQuery] GetEmployeesQuery query)
    {
        return Ok( await _mediator.Send(query));
    }

    [HttpGet("employeeId")]
    public async Task<ActionResult<EmployeeDto>> GetEmployeeById([FromQuery] GetEmployeeByIdQuery query)
    {
        return Ok( await _mediator.Send(query));
    }

    [HttpPut]
    public async Task<ActionResult> UpdateEmployee([FromBody] UpdateEmployeeCommand command)
    {
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    public async Task<ActionResult> DeleteEmployee([FromQuery] DeleteEmployeeCommand command)
    {
        await _mediator.Send(command);
        return NoContent();
    }
}