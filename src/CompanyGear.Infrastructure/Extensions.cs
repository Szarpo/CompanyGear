using System.Reflection;
using CompanyGear.Application.Security;
using CompanyGear.Core.Repositories;
using CompanyGear.Infrastructure.DAL;
using CompanyGear.Infrastructure.DAL.Repositories;
using CompanyGear.Infrastructure.Security;
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
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddPostgres(configuration);
        services.AddSecurity();

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