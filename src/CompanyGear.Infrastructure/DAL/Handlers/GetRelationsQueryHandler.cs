using CompanyGear.Application.DTO;
using CompanyGear.Application.Queries;
using CompanyGear.Core.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CompanyGear.Infrastructure.DAL.Handlers;

internal sealed class GetRelationsQueryHandler : IRequestHandler<GetRelationsQuery, IEnumerable<RelationDto>>
{
    private readonly CompanyDeviceDbContext _dbContext;
    public GetRelationsQueryHandler(CompanyDeviceDbContext dbContext, IEmployeeRepository employeeRepository) => _dbContext = dbContext;
    
    
    public async Task<IEnumerable<RelationDto>> Handle(GetRelationsQuery request, CancellationToken cancellationToken)
    {
        var relations = await _dbContext.Relations.AsNoTracking().ToListAsync(cancellationToken: cancellationToken);

        var relationDetailList = new List<RelationDto>();

        foreach (var relation in relations)
        {
            var employee = await _dbContext.Employees.Where(x => x.Id == relation.EmployeeId).FirstOrDefaultAsync(cancellationToken: cancellationToken);

            var gear = await _dbContext.Devices.Where(x => x.Id == relation.GearId).FirstOrDefaultAsync(cancellationToken: cancellationToken);

            var relationDetails = new RelationDto
            {
                Id = relation.Id,
                Employee = employee.EmployeeAsDto(),
                Gear = gear.DeviceAsDto(),
                RelationStatus = relation.RelationStatus,
            };
            
            relationDetailList.Add(relationDetails);
        }
        
        
        return relationDetailList;
    }
}