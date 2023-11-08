using CompanyGear.Core.Repositories;
using CompanyGear.Infrastructure.DAL.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace CompanyGear.Infrastructure;

public static class Extensions 
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection service)
    {
        service.AddScoped<IEmployeeRepository, EmployeeRepository>();

        return service;
    }
}