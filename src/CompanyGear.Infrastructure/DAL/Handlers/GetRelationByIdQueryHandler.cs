using CompanyGear.Application.DTO;
using CompanyGear.Application.Queries;
using CompanyGear.Core.Exceptions;
using CompanyGear.Core.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CompanyGear.Infrastructure.DAL.Handlers;

internal sealed class GetRelationByIdQueryHandler : IRequestHandler<GetRelationByIdQuery, RelationDto>
{

    private readonly CompanyDeviceDbContext _dbContext;
    private readonly IRelationRepository _relationRepository;

    public GetRelationByIdQueryHandler(CompanyDeviceDbContext dbContext, IRelationRepository relationRepository)
    {
        _dbContext = dbContext;
        _relationRepository = relationRepository;
    }

        public async Task<RelationDto> Handle(GetRelationByIdQuery request, CancellationToken cancellationToken)
        {
            var isExist = await _relationRepository.IsExistId(relationId: request.RelationId);

            if (!isExist)
            {
                throw new InvalidNotExistIdException(id: request.RelationId);
            }
        
        var relation = await _dbContext.Relations.AsNoTracking().FirstOrDefaultAsync(x => x.Id == request.RelationId, cancellationToken: cancellationToken);

        var employee = await _dbContext.Employees.AsNoTracking().FirstOrDefaultAsync(x => x.Id == relation.EmployeeId, cancellationToken: cancellationToken);

        var gear = await _dbContext.Devices.AsNoTracking().FirstOrDefaultAsync(x => x.Id == relation.DeviceId, cancellationToken: cancellationToken);

        return relation?.RelationEmployeeWithDeviceAsDto(employee: employee, device: gear);
    }
}