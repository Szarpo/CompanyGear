using MediatR;

namespace CompanyGear.Application.Commands;

public sealed record SignInCommand(string Login, string Password) : IRequest;