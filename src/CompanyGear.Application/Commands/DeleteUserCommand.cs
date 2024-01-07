using MediatR;

namespace CompanyGear.Application.Commands;

public record DeleteUserCommand() : IRequest;