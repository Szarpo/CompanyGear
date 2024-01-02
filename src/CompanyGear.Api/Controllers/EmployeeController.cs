using CompanyGear.Application.Commands;
using CompanyGear.Application.DTO;
using CompanyGear.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CompanyGear.Api.Controllers;


[ApiController]
[Route("employee")]
[Authorize(policy: "is-admin")]
public class EmployeeController : ControllerBase
{
    private readonly IMediator _mediator;

    public EmployeeController(
        IMediator mediator) => _mediator = mediator;
    
    
    [HttpPost]
    [SwaggerOperation("Create new employee")]
    public async Task<ActionResult> CreateEmployeeCommand(CreateEmployeeCommand command)
    { 
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpGet]
    [SwaggerOperation("Get all employees")]
    public async Task<ActionResult<IEnumerable<EmployeeDto>>> GetEmployees([FromQuery] GetEmployeesQuery query)
    {
        return Ok( await _mediator.Send(query));
    }

    [HttpGet("employeeId")]
    [SwaggerOperation("Get employee by ID")]

    public async Task<ActionResult<EmployeeDto>> GetEmployeeById([FromQuery] GetEmployeeByIdQuery query)
    {
        return Ok( await _mediator.Send(query));
    }

    [HttpPut]
    [SwaggerOperation("Update employee data")]

    public async Task<ActionResult> UpdateEmployee([FromBody] UpdateEmployeeCommand command)
    {
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [SwaggerOperation("Delete employee")]

    public async Task<ActionResult> DeleteEmployee([FromQuery] DeleteEmployeeCommand command)
    {
        await _mediator.Send(command);
        return NoContent();
    }
}