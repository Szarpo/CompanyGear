using CompanyGear.Application.Security;
using CompanyGear.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace CompanyGear.Infrastructure.Security;

internal static class Extensions
{

    public static IServiceCollection AddSecurity(this IServiceCollection services)
    {

        services
            .AddSingleton<IPasswordManager, PasswordManager>()
            .AddSingleton<IPasswordHasher<User>, PasswordHasher<User>>();
        
        return services;
    }
    
}