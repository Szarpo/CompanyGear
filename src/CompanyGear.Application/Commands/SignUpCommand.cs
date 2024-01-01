using MediatR;

namespace CompanyGear.Application.Commands;

public sealed record SignUpCommand(string Login, string FullName, string Password) : IRequest;
