using CompanyGear.Core.Entities;
using CompanyGear.Core.Exceptions;
using CompanyGear.Core.Repositories;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CompanyGear.Application.Commands.Handlers;

public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand>
{

    private readonly IUserRepository _userRepository;

    public DeleteUserCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    
    public async Task Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        
        var isExist = await _userRepository.UserExist(request.UserId);

        if (!isExist)
        {
            throw new InvalidUserNotExistException(request.UserId);
        }
        
        
        var user = await _userRepository.GetById(request.UserId);

        await _userRepository.DeleteUser(user);
    }
}