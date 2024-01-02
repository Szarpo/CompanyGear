
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

    public static DeviceDto DeviceAsDto(this Device entity) => new()
    {
        Id = entity.Id,
        TypeOfDevice = entity.TypeOfDevice,
        Model = entity.Model,
        SerialNumber = entity.SerialNumber,
        UteNumber = entity.UteNumber,
        
    };

    public static RelationDto RelationEmployeeWithDeviceAsDto(this Relation relation, Employee employee, Device device)
    {
        return new RelationDto()
        {
            Id = relation.Id,
            Employee = employee.EmployeeAsDto(),
            Gear = device.DeviceAsDto(),
            RelationStatus = relation.RelationStatus,
        };
    }

    public static UserDto UserAsDto(this User entity) => new()
    {
        Id = entity.Id,
        Login = entity.Login,
        Fullname = entity.FullName,
        CreatedAt = entity.CreatedAt,
        Role = entity.Role,
    };



}