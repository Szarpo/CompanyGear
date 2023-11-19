using CompanyGear.Infrastructure.DAL.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CompanyGear.Infrastructure.DAL;

internal static class Extensions
{

    private const string OptionsSectionName = "postgres";

    public static IServiceCollection AddPostgres(this IServiceCollection services, IConfiguration configuration)
    {
        var postgresOptions = configuration.GetConnectionString(OptionsSectionName);
        services.AddDbContext<CompanyGearDbContext>(x => x.UseNpgsql(postgresOptions));
        
        return services;
    }

}