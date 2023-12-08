using CompanyGear.Application.DTO;
using CompanyGear.Application.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CompanyGear.Infrastructure.DAL.Handlers;

internal sealed class GetGearByIdQueryHandler : IRequestHandler<GetGearByIdQuery, GearDto>
{
    private readonly CompanyGearDbContext _dbContext;

    public GetGearByIdQueryHandler(CompanyGearDbContext dbContext) => _dbContext = dbContext;
    
    public async Task<GearDto> Handle(GetGearByIdQuery request, CancellationToken cancellationToken)
    {
        var gear = await _dbContext.Gears.AsNoTracking().FirstOrDefaultAsync(x => x.Id == request.GearId, cancellationToken: cancellationToken);

        return gear.GearAsDto();
    }
}