using CompanyGear.Application.Security;
using MediatR;

namespace CompanyGear.Application.Commands.Handlers;

public class SignOutCommandHandler : IRequestHandler<SignOutCommand>
{
    private readonly ITokenStorage _tokenStorage;

    public SignOutCommandHandler(ITokenStorage tokenStorage)
    {
        _tokenStorage = tokenStorage;
    }
    
    public Task Handle(SignOutCommand request, CancellationToken cancellationToken)
    {
         _tokenStorage.Remove();

         return Task.CompletedTask;

    }
}