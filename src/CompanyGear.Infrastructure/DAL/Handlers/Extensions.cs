
using CompanyGear.Application.DTO;
using CompanyGear.Core.Entities;

namespace CompanyGear.Infrastructure.DAL.Handlers;

public static class Extensions
{
    public static EmployeeDto EmployeeAsDto(this Employee entity) => new()
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
        
    };

    public static RelationDto RelationEmployeeWithGearAsDto(this Relation relation, Employee employee, Gear gear)
    {
        return new RelationDto()
        {
            Id = relation.Id,
            Employee = employee.EmployeeAsDto(),
            Gear = gear.GearAsDto(),
        };
    }
    


}