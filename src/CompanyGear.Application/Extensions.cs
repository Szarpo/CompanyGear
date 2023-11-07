using Microsoft.Extensions.DependencyInjection;

namespace CompanyGear.Application;

public static class Extensions 
{
    public static IServiceCollection AddApplication(this IServiceCollection service)
    {
        return service;
    }
}