using CompanyGear.Application.DTO;
using MediatR;

namespace CompanyGear.Application.Queries;

public sealed record GetUserByIdQuery(Guid Id) : IRequest<UserDto>;