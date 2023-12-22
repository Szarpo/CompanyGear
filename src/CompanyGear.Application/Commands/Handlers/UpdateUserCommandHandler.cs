using CompanyGear.Core.Exceptions;
using CompanyGear.Core.Repositories;
using MediatR;

namespace CompanyGear.Application.Commands.Handlers;

public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand>
{

    private readonly IUserRepository _userRepository;

    public UpdateUserCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    
    public async Task Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {

        var (id, login, fullname) = request;
        
        var isExist = await _userRepository.UserExist(id);

        if (!isExist)
        {
            throw new InvalidUserNotExistException(id);
        }
        
        var user = await _userRepository.GetById(id);
        user.Update(login: login, fullName: fullname);
        
        await _userRepository.Update(user);
    }
}