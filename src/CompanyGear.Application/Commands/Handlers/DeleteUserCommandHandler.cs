using CompanyGear.Core.Exceptions;
using CompanyGear.Core.Repositories;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace CompanyGear.Application.Commands.Handlers;

public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand>
{

    private readonly IUserRepository _userRepository;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public DeleteUserCommandHandler(IUserRepository userRepository, IHttpContextAccessor httpContextAccessor)
    {
        _userRepository = userRepository;
        _httpContextAccessor = httpContextAccessor;
    }
    
    public async Task Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var userId = Guid.Parse(_httpContextAccessor.HttpContext!.User.Identity!.Name!);
        
        var isExist = await _userRepository.UserExist(userId);

        if (!isExist)
        {
            throw new InvalidUserNotExistException(userId);
        }
        
        
        var user = await _userRepository.GetById(userId);

        await _userRepository.DeleteUser(user);
    }
}