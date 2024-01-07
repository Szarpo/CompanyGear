using System.Security.Authentication;
using CompanyGear.Application.Security;
using CompanyGear.Core.Repositories;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace CompanyGear.Application.Commands.Handlers;

public class SignInCommandHandler : IRequestHandler<SignInCommand>
{

    private readonly IUserRepository _userRepository;
    private readonly IAuthenticator _authenticator;
    private readonly ITokenStorage _tokenStorage;
    private readonly IPasswordManager _passwordManager;

    public SignInCommandHandler(IUserRepository userRepository, IAuthenticator authenticator, ITokenStorage tokenStorage, IPasswordManager passwordManager)
    {
        _userRepository = userRepository;
        _authenticator = authenticator;
        _tokenStorage = tokenStorage;
        _passwordManager = passwordManager;
    }
    
    public async Task Handle(SignInCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByLogin(request.Login);
        
        if (user is null)
        {
            throw new InvalidCredentialException();
        }

        if (!_passwordManager.ValidatePassword(request.Password, user!.Password))
        {
            throw new InvalidCredentialException();
        }

        var jwt =  _authenticator.CreateToken(user.Id, user.Role);
        
        _tokenStorage.Set(jwt);
    }
}