using CompanyGear.Application.DTO;
using MediatR;

namespace CompanyGear.Application.Queries;

public sealed record GetUsersQuery() : IRequest<IEnumerable<UserDto>>;