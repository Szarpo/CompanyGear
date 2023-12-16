using System.Reflection;
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
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IEmployeeRepository, EmployeeRepository>();
        services.AddScoped<IGearRepository, GearRepository>();
        services.AddScoped<IRelationRepository, RelationRepository>();
        services.AddPostgres(configuration);

        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

        
        return services;
    }
    
    public static T GetOptions<T>(this IConfiguration configuration, string sectionName) where T : class, new()
    {
        var options = new T();
        var section = configuration.GetRequiredSection(sectionName);
        section.Bind(options);
        return options;
    }
}