using CompanyGear.Application.Security;
using CompanyGear.Core.Entities;
using CompanyGear.Core.Repositories;
using MediatR;

namespace CompanyGear.Application.Commands.Handlers;

public class SingUpCommandHandler : IRequestHandler<SingUpCommand>
{

    private readonly IPasswordManager? _passwordManager;
    private readonly IUserRepository _userRepository;

    public SingUpCommandHandler(IPasswordManager passwordManager, IUserRepository userRepository)
    {
        _passwordManager = _passwordManager;
        _userRepository = userRepository;
    }
    
    public async Task Handle(SingUpCommand request, CancellationToken cancellationToken)
    {
        var (login, fullName, password) = request;
        var securedPassword = _passwordManager!.Password(password: password);
        var user = User.CreateAccount(login: login, fullName: fullName, password: securedPassword);
        await _userRepository.SignUp(user);
        
    }
}