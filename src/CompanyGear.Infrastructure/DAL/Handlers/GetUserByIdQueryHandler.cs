using CompanyGear.Application.DTO;
using CompanyGear.Application.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CompanyGear.Infrastructure.DAL.Handlers;

internal sealed class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserDto>
{

    private readonly CompanyDeviceDbContext _dbContext;

    public GetUserByIdQueryHandler(CompanyDeviceDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<UserDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var user = await _dbContext.Users.AsNoTracking().FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken: cancellationToken);

        return user.UserAsDto();
    }
}