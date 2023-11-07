using CompanyGear.Application.Abstractions;
using CompanyGear.Application.Commands;
using CompanyGear.Application.Commands.Handlers;
using Microsoft.Extensions.DependencyInjection;

namespace CompanyGear.Application;

public static class Extensions 
{
    public static IServiceCollection AddApplication(this IServiceCollection service)
    {
        service.AddScoped<ICommandHandler<CreateEmployeeCommand>, CreateEmployeeCommandHandler>();
        return service;
    }
}