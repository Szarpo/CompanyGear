using CompanyGear.Core.Exceptions;
using CompanyGear.Core.Repositories;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace CompanyGear.Application.Commands.Handlers;

public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand>
{

    private readonly IUserRepository _userRepository;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public UpdateUserCommandHandler(IUserRepository userRepository, IHttpContextAccessor httpContextAccessor)
    {
        _userRepository = userRepository;
        _httpContextAccessor = httpContextAccessor;
    }
    
    public async Task Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {

        var (login, fullname) = request;

        var userId = Guid.Parse(_httpContextAccessor.HttpContext!.User.Identity!.Name!);
        
        var isExist = await _userRepository.UserExist(userId);

        if (!isExist)
        {
            throw new InvalidUserNotExistException(userId);
        }
        
        var user = await _userRepository.GetById(userId);
        user.Update(login: login, fullName: fullname);
        
        await _userRepository.Update(user);
    }
}