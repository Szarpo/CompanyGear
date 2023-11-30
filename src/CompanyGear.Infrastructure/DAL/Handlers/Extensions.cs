using CompanyGear.Application.DTO;
using CompanyGear.Core.Entities;
using CompanyGear.Core.ValueObjects;

namespace CompanyGear.Infrastructure.DAL.Handlers;

public static class Extensions
{
    public static EmployeeDto AsDto(this Employee entity) => new()
    {
        EmployeeId = entity.Id,
        FirstName = entity.FirstName,
        LastName = entity.LastName,
        Department = entity.Department,
        EmployeeNumber = entity.EmployeeNumber

    };

    public static GearDto GearAsDto(this Gear entity) => new()
    {
        Id = entity.Id,
        TypeOfDevice = entity.TypeOfDevice,
        Model = entity.Model,
        SerialNumber = entity.SerialNumber,
        UteNumber = entity.UteNumber,
        EmployeeId = entity.EmployeeId
        
    };

    public static EmployeeWithGearDto EmployeeWithGearAsDto(this Gear entity) => new()
    {
        EmployeeId = entity.EmployeeId,
        FirstName = entity.Employee.FirstName,
        LastName = entity.Employee.LastName,
        Department = entity.Employee.Department,
        EmployeeNumber = entity.Employee.EmployeeNumber,
        Gear = entity.GearAsDto(),
    };

}