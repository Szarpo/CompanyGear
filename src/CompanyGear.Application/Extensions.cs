using System.Reflection;
using CompanyGear.Application.Abstractions;
using CompanyGear.Application.Commands;
using CompanyGear.Application.Commands.Handlers;
using MediatR;
using Microsoft.Extensions.DependencyInjection;


namespace CompanyGear.Application;

public static class Extensions 
{
    public static IServiceCollection AddApplication(this IServiceCollection service)
    {

        service.AddScoped<ICommandHandler<CreateEmployeeCommand>, CreateEmployeeCommandHandler>();
        service.AddScoped<ICommandHandler<UpdateEmployeeCommand>, UpdateEmployeeCommandHandler>();
        service.AddScoped<ICommandHandler<DeleteEmployeeCommand>, DeleteEmployeeCommandHandler>();
        service.AddScoped<ICommandHandler<CreateGearCommand>, CreateGearCommandHandler>();
        service.AddScoped<ICommandHandler<DeleteGearCommand>, DeleteGearCommandHandler>();

        service.AddScoped<IRequestHandler<DeleteRelationCommand, Unit>, DeleteRelationCommandHandler>();
        
        return service;
    }
}  