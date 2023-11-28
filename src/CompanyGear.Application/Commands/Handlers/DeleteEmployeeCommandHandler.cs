using CompanyGear.Application.Abstractions;
using CompanyGear.Core.Repositories;

namespace CompanyGear.Application.Commands.Handlers;

public sealed class DeleteEmployeeCommandHandler : ICommandHandler<DeleteEmployeeCommand>
{

    private readonly IEmployeeRepository _repository;

    public DeleteEmployeeCommandHandler(IEmployeeRepository repository)
    {
        _repository = repository;
    }
    public async Task HandleAsync(DeleteEmployeeCommand command)
    {

        var employeeToDelete = await _repository.GetEmployeeById(command.EmployeeId);
        await _repository.Delete(employeeToDelete);

    }
}