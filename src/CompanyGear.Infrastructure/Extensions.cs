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

        services
            .AddHttpContextAccessor()
            .AddPostgres(configuration)
            .AddSingleton<IClock, Clock>()
            .AddSecurity()
            .AddAuth(configuration);

        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

        
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(swagger=>
            {
                swagger.EnableAnnotations();
                swagger.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Company Gear",
                    Version = "v1"
                });
                swagger.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Bearer {token}\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT"
                    
                });
                swagger.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme {
                            Reference = new OpenApiReference {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] {}
                    }
                }
                );
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