using CompanyGear.Application.DTO;
using CompanyGear.Application.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CompanyGear.Infrastructure.DAL.Handlers;

internal sealed class GetGearsQueryHandler : IRequestHandler<GetGearsQuery, IEnumerable<GearDto>>
{
    private readonly CompanyGearDbContext _dbContext;

    public GetGearsQueryHandler(CompanyGearDbContext dbContext) => _dbContext = dbContext;
    
    public async Task<IEnumerable<GearDto>> Handle(GetGearsQuery request, CancellationToken cancellationToken) => await _dbContext.Gears.AsNoTracking().Select(x => x.GearAsDto()).ToListAsync(cancellationToken: cancellationToken);
}