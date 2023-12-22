using CompanyGear.Core.Exceptions;
using CompanyGear.Core.Repositories;
using CompanyGear.Core.ValueObjects;
using MediatR;

namespace CompanyGear.Application.Commands.Handlers;

public class ChangeRoleCommandHandler : IRequestHandler<ChangeRoleCommand>
{

    private readonly IUserRepository _userRepository;

    public ChangeRoleCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    
    public async Task Handle(ChangeRoleCommand request, CancellationToken cancellationToken)
    {
        var isExist =await  _userRepository.UserExist(request.UserId);

        if (!isExist)
        {
            throw new InvalidUserNotExistException(request.UserId);
        }
        
        var user = await _userRepository.GetById(request.UserId);
        
        user.ChangeRole(role: new Role(request.Role));

        await _userRepository.ChangeRole(user: user);
    }
}