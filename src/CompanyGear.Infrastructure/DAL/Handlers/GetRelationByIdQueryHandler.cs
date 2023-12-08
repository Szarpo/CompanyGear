using CompanyGear.Application.DTO;
using CompanyGear.Application.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CompanyGear.Infrastructure.DAL.Handlers;

internal sealed class GetRelationByIdQueryHandler : IRequestHandler<GetRelationByIdQuery, RelationDto>
{

    private readonly CompanyGearDbContext _dbContext;

    public GetRelationByIdQueryHandler(CompanyGearDbContext dbContext) =>  _dbContext = dbContext;

        public async Task<RelationDto> Handle(GetRelationByIdQuery request, CancellationToken cancellationToken)
    {
        var relation = await _dbContext.Relations.AsNoTracking().FirstOrDefaultAsync(x => x.Id == request.RelationId, cancellationToken: cancellationToken);

        var employee = await _dbContext.Employees.AsNoTracking().FirstOrDefaultAsync(x => x.Id == relation.EmployeeId, cancellationToken: cancellationToken);

        var gear = await _dbContext.Gears.AsNoTracking().FirstOrDefaultAsync(x => x.Id == relation.GearId, cancellationToken: cancellationToken);

        return relation?.RelationEmployeeWithGearAsDto(employee: employee, gear: gear);
    }
}