using MediatR;

namespace CompanyGear.Application.Commands;

public sealed record SingUpCommand(string Login, string FullName, string Password) : IRequest;
