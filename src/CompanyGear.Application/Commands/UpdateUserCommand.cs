using MediatR;

namespace CompanyGear.Application.Commands;

public sealed record UpdateUserCommand(string Login, string FullName) : IRequest;