using CompanyGear.Application.DTO;
using CompanyGear.Application.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CompanyGear.Infrastructure.DAL.Handlers;

internal sealed class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, IEnumerable<UserDto>>
{
    private readonly CompanyDeviceDbContext _dbContext;

    public GetUsersQueryHandler(CompanyDeviceDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<UserDto>> Handle(GetUsersQuery request, CancellationToken cancellationToken) =>
        await _dbContext.Users.AsNoTracking().Select(x => x.UserAsDto()).ToListAsync(cancellationToken: cancellationToken);
}