using CompanyGear.Application.DTO;
using CompanyGear.Application.Queries;
using CompanyGear.Core.Exceptions;
using CompanyGear.Core.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CompanyGear.Infrastructure.DAL.Handlers;

internal sealed class GetGearByIdQueryHandler : IRequestHandler<GetGearByIdQuery, GearDto>
{
    private readonly CompanyGearDbContext _dbContext;
    private readonly IGearRepository _gearRepository;

    public GetGearByIdQueryHandler(CompanyGearDbContext dbContext, IGearRepository gearRepository)
    {
        _dbContext = dbContext;
        _gearRepository = gearRepository;
    }
    
    public async Task<GearDto> Handle(GetGearByIdQuery request, CancellationToken cancellationToken)
    {
        var isExist =await  _gearRepository.IsExist(request.GearId);
        if (!isExist)
        {
            throw new InvalidNotExistIdException(id: request.GearId);
        }
        var gear = await _dbContext.Gears.AsNoTracking().FirstOrDefaultAsync(x => x.Id == request.GearId, cancellationToken: cancellationToken);

        return gear.GearAsDto();
    }
}