using MediatR;

namespace CompanyGear.Application.Commands;

public record DeleteUserCommand(Guid UserId) : IRequest;