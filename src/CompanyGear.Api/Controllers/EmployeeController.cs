using CompanyGear.Application.Abstractions;
using CompanyGear.Application.Commands;
using Microsoft.AspNetCore.Mvc;

namespace CompanyGear.Api.Controllers;


[ApiController]
[Route("employee")]
public class EmployeeController : ControllerBase
{
    private readonly ICommandHandler<CreateEmployeeCommand> _createEmployee;

    public EmployeeController(ICommandHandler<CreateEmployeeCommand> createEmployee)
    {
        _createEmployee = createEmployee;
    }
    
    [HttpPost("/create")]
    public async Task<ActionResult> CreateEmployeeCommand(CreateEmployeeCommand command)
    {
        await _createEmployee.HandleAsync(new CreateEmployeeCommand(FirstName: command.FirstName, LastName: command.LastName, EmployeeNumber: command.EmployeeNumber, Department: command.Department));
        
        return NoContent();
    }
}