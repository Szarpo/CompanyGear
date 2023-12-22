using CompanyGear.Core.Enums;
using MediatR;

namespace CompanyGear.Application.Commands;

public sealed record ChangeRoleCommand(Guid UserId, RoleEnum Role) : IRequest;