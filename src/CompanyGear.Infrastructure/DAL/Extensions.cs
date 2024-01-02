using CompanyGear.Core.Repositories;
using CompanyGear.Infrastructure.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CompanyGear.Infrastructure.DAL;

internal static class Extensions
{

    private const string OptionsSectionName = "postgres";

    public static IServiceCollection AddPostgres(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IEmployeeRepository, EmployeeRepository>();
        services.AddScoped<IDeviceRepository, DeviceRepository>();
        services.AddScoped<IRelationRepository, RelationRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        
        services.Configure<Configurations.PostgresOptions>(configuration.GetRequiredSection(OptionsSectionName));
        var postgresOptions = configuration.GetOptions<Configurations.PostgresOptions>(OptionsSectionName);
        services.AddDbContext<CompanyDeviceDbContext>(x => x.UseNpgsql(postgresOptions.ConnectionString));
        
        return services;
    }

}