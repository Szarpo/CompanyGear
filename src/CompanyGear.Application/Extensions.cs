using System.Reflection;
using Microsoft.Extensions.DependencyInjection;


namespace CompanyGear.Application;

public static class Extensions 
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        return services;
    }
}  