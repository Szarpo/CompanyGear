using CompanyGear.Application.Abstractions;
using CompanyGear.Application.DTO;
using CompanyGear.Application.Queries;
using Microsoft.EntityFrameworkCore;

namespace CompanyGear.Infrastructure.DAL.Handlers;

internal sealed class GetGearsQueryHandler : IQueryHandler<GetGearsQuery, IEnumerable<GearDto>>
{
    private readonly CompanyGearDbContext _dbContext;

    public GetGearsQueryHandler(CompanyGearDbContext dbContext)=>  _dbContext = dbContext;
    
    
    public async Task<IEnumerable<GearDto>> HandleASync(GetGearsQuery query) => await _dbContext.Gears.AsNoTracking().Select(x => x.GearAsDto()).ToListAsync();

}