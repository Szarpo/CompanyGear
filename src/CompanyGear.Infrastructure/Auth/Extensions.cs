using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CompanyGear.Infrastructure.Auth;

public static class Extensions
{
    private const string OptionSectionName = "auth";
    public static IServiceCollection AddAuth(this IServiceCollection services, IConfiguration configuration)
    {
        var options = configuration.GetOptions<AuthOptions>(OptionSectionName);
        
        
        
        return services;
    }
}