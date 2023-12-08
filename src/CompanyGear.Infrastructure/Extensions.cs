using CompanyGear.Application.DTO;
using CompanyGear.Application.Queries;
using CompanyGear.Core.Repositories;
using CompanyGear.Infrastructure.DAL;
using CompanyGear.Infrastructure.DAL.Handlers;
using CompanyGear.Infrastructure.DAL.Repositories;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CompanyGear.Infrastructure;

public static class Extensions 
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection service, IConfiguration configuration)
    {
        service.AddScoped<IEmployeeRepository, EmployeeRepository>();
        service.AddScoped<IGearRepository, GearRepository>();
        service.AddScoped<IRelationRepository, RelationRepository>();
        service.AddPostgres(configuration);


        service.AddScoped<IRequestHandler<GetRelationsQuery, IEnumerable<RelationDto>>, GetRelationsQueryHandler>();
        service.AddScoped<IRequestHandler<GetRelationByIdQuery, RelationDto>, GetRelationByIdQueryHandler>();
        service.AddScoped<IRequestHandler<GetGearByIdQuery, GearDto>, GetGearByIdQueryHandler>();
        service.AddScoped<IRequestHandler<GetGearsQuery, IEnumerable<GearDto>>, GetGearsQueryHandler>();
        service.AddScoped<IRequestHandler<GetEmployeeByIdQuery, EmployeeDto>, GetEmployeeByIdQueryHandler>();
        service.AddScoped<IRequestHandler<GetEmployeesQuery, IEnumerable<EmployeeDto>>, GetEmployeesQueryHandler>();


        return service;
    }
    
    public static T GetOptions<T>(this IConfiguration configuration, string sectionName) where T : class, new()
    {
        var options = new T();
        var section = configuration.GetRequiredSection(sectionName);
        section.Bind(options);
        return options;
    }
}