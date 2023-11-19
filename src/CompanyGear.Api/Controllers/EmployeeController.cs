using CompanyGear.Application.Abstractions;
using CompanyGear.Application.Commands;
using CompanyGear.Application.DTO;
using CompanyGear.Application.Queries;
using Microsoft.AspNetCore.Mvc;

namespace CompanyGear.Api.Controllers;


[ApiController]
[Route("employee")]
public class EmployeeController : ControllerBase
{
    private readonly ICommandHandler<CreateEmployeeCommand> _createEmployee;
    private readonly IQueryHandler<GetEmployeesQuery, IEnumerable<EmployeeDto>> _getEmployees;

    public EmployeeController(ICommandHandler<CreateEmployeeCommand> createEmployee, IQueryHandler<GetEmployeesQuery, IEnumerable<EmployeeDto>> getEmployees)
    {
        _createEmployee = createEmployee;
        _getEmployees = getEmployees;
    }
    
    [HttpPost("/create")]
    public async Task<ActionResult> CreateEmployeeCommand(CreateEmployeeCommand command)
    {
        await _createEmployee.HandleAsync(new CreateEmployeeCommand(FirstName: command.FirstName, LastName: command.LastName, EmployeeNumber: command.EmployeeNumber, Department: command.Department));
        
        return NoContent();
    }

    [HttpGet("/getAllEmployees")]
    public async Task<ActionResult> GetEmployees([FromQuery] GetEmployeesQuery query)
    {
      
        return Ok( await _getEmployees.HandleASync(query));
    }
}