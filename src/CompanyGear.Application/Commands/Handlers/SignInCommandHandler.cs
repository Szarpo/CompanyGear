using CompanyGear.Application.Security;
using CompanyGear.Core.Repositories;
using MediatR;

namespace CompanyGear.Application.Commands.Handlers;

public class SignInCommandHandler : IRequestHandler<SignInCommand>
{

    private readonly IUserRepository _userRepository;
    private readonly IAuthenticator _authenticator;
    private readonly ITokenStorage _tokenStorage;

    public SignInCommandHandler(IUserRepository userRepository, IAuthenticator authenticator, ITokenStorage tokenStorage)
    {
        _userRepository = userRepository;
        _authenticator = authenticator;
        _tokenStorage = tokenStorage;
    }
    
    public async Task Handle(SignInCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByLogin(request.Login);

        var jwt =  _authenticator.CreateToken(user.Id, user.Role);
        
        _tokenStorage.Set(jwt);
    }
}