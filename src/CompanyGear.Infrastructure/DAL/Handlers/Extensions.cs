
using CompanyGear.Application.DTO;
using CompanyGear.Core.Entities;

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

    public static GearWithEmployeeDto GearWithEmployeeAsDto(this Gear gear) => new()
    {
        Id = gear.Id,
        TypeOfDevice = gear.TypeOfDevice,
        Model = gear.Model,
        SerialNumber = gear.SerialNumber,
        UteNumber = gear.UteNumber,
        Employee = gear.Employee.AsDto()
        
    };

}