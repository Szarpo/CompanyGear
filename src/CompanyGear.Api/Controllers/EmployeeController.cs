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
    private readonly ICommandHandler<UpdateEmployeeCommand> _updateEmployee;
    private readonly IQueryHandler<GetEmployeesQuery, IEnumerable<EmployeeDto>> _getEmployees;
    private readonly IQueryHandler<GetEmployeeByIdQuery, EmployeeDto> _getEmployeeById;

    public EmployeeController(ICommandHandler<CreateEmployeeCommand> createEmployee, IQueryHandler<GetEmployeesQuery, IEnumerable<EmployeeDto>> getEmployees, IQueryHandler<GetEmployeeByIdQuery, EmployeeDto> getEmployeeById,
     ICommandHandler<UpdateEmployeeCommand> updateEmployee)
    {
        _createEmployee = createEmployee;
        _getEmployees = getEmployees;
        _getEmployeeById = getEmployeeById;
        _updateEmployee = updateEmployee;
    }
    
    [HttpPost("/create")]
    public async Task<ActionResult> CreateEmployeeCommand(CreateEmployeeCommand command)
    {
        await _createEmployee.HandleAsync(new CreateEmployeeCommand(FirstName: command.FirstName, LastName: command.LastName, EmployeeNumber: command.EmployeeNumber, Department: command.Department));
        
        return NoContent();
    }

    [HttpGet("/getAllEmployees")]
    public async Task<ActionResult<IEnumerable<EmployeeDto>>> GetEmployees([FromQuery] GetEmployeesQuery query)
    {
      
        return Ok( await _getEmployees.HandleASync(query));
    }

    [HttpGet("/getEmployeeById/{employeeId:guid}")]
    public async Task<ActionResult<EmployeeDto>> GetEmployeeById(Guid employeeId)
    {
        return Ok( await _getEmployeeById.HandleASync(new GetEmployeeByIdQuery {EmployeeId = employeeId}));
    }

    [HttpPut()]
    public async Task<ActionResult> UpdateEmployee([FromBody] UpdateEmployeeCommand command)
    {
        await _updateEmployee.HandleAsync(command);
        return NoContent();
    }
}