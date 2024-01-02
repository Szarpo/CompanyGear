using MediatR;

namespace CompanyGear.Application.Commands;

public sealed record SignOutCommand() : IRequest;