using CompanyGear.Core.Repositories;
using MediatR;

namespace CompanyGear.Application.Commands.Handlers;

public sealed class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand>
{

    private readonly IEmployeeRepository _repository;

    public DeleteEmployeeCommandHandler(IEmployeeRepository repository)
    {
        _repository = repository;
    }

    public async Task<Unit> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
    {
        var employeeToDelete = await _repository.GetEmployeeById(request.EmployeeId);
        await _repository.Delete(employeeToDelete);
        return Unit.Value;
    }
}