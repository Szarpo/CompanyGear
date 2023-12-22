using MediatR;

namespace CompanyGear.Application.Commands;

public sealed record UpdateUserCommand(Guid UserId, string Login, string FullName) : IRequest;