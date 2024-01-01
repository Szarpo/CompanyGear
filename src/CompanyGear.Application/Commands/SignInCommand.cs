using MediatR;

namespace CompanyGear.Application.Commands;

public record SignInCommand(string Login, string Password) : IRequest;