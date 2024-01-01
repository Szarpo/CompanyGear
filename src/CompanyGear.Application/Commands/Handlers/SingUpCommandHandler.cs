using CompanyGear.Application.Security;
using CompanyGear.Core.Entities;
using CompanyGear.Core.Exceptions;
using CompanyGear.Core.Repositories;
using MediatR;

namespace CompanyGear.Application.Commands.Handlers;

public class SingUpCommandHandler : IRequestHandler<SignUpCommand>
{

    private readonly IPasswordManager? _passwordManager;
    private readonly IUserRepository _userRepository;

    public SingUpCommandHandler(IPasswordManager passwordManager, IUserRepository userRepository)
    {
        _passwordManager = passwordManager;
        _userRepository = userRepository;
    }
    
    public async Task Handle(SignUpCommand request, CancellationToken cancellationToken)
    {
        var (login, fullName, password) = request;
        var loginIsExist = await _userRepository.LoginIsExist(login: login);

        if (loginIsExist)
        {
            throw new InvalidLoginExistException();
        }
        
        var securedPassword = _passwordManager!.Password(password: password);
        var user = User.CreateAccount(login: login, fullName: fullName, password: securedPassword);
        await _userRepository.SignUp(user);
        
    }
}