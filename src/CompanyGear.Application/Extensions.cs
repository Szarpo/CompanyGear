using CompanyGear.Application.Commands;
using CompanyGear.Application.Commands.Handlers;
using MediatR;
using Microsoft.Extensions.DependencyInjection;


namespace CompanyGear.Application;

public static class Extensions 
{
    public static IServiceCollection AddApplication(this IServiceCollection service)
    {

        service.AddScoped<IRequestHandler<DeleteRelationCommand, Unit>, DeleteRelationCommandHandler>();
        service.AddScoped<IRequestHandler<CreateGearCommand, Unit>, CreateGearCommandHandler>();
        service.AddScoped<IRequestHandler<DeleteGearCommand, Unit>, DeleteGearCommandHandler>();
        service.AddScoped<IRequestHandler<DeleteEmployeeCommand, Unit>, DeleteEmployeeCommandHandler>();
        service.AddScoped<IRequestHandler<UpdateEmployeeCommand, Unit>, UpdateEmployeeCommandHandler>();
        service.AddScoped<IRequestHandler<CreateEmployeeCommand, Unit>, CreateEmployeeCommandHandler>();
        
        return service;
    }
}  