using CompanyGear.Application.Abstractions;

namespace CompanyGear.Application.Commands.Handlers;

public sealed class CreateEmployeeCommandHandler : ICommandHandler<CreateEmployeeCommand>
{
    public Task HandleAsync(CreateEmployeeCommand command)
    {
        throw new NotImplementedException();
    }
}