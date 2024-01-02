using System.Reflection;
using CompanyGear.Core.Abstractions;
using CompanyGear.Infrastructure.Auth;
using CompanyGear.Infrastructure.DAL;
using CompanyGear.Infrastructure.Security;
using CompanyGear.Infrastructure.Time;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace CompanyGear.Infrastructure;

public static class Extensions 
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddHttpContextAccessor();

        services
            .AddPostgres(configuration)
            .AddSingleton<IClock, Clock>()
            .AddSecurity();

        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

        services.AddAuth(configuration);
        
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(swagger=>

            {
                swagger.EnableAnnotations();
                swagger.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Company Gear",
                    Version = "v1"
                });
            }
            
            );


        
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