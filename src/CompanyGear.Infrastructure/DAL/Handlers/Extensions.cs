using CompanyGear.Application.DTO;
using CompanyGear.Core.Entities;

namespace CompanyGear.Infrastructure.DAL.Handlers;

public static class Extensions
{
    public static EmployeeDto AsDto(this Employee entity) => new()
    {
        EmployeeId = entity.EmployeeId,
        FirstName = entity.FirstName,
        LastName = entity.LastName,
        Department = entity.Department,
        EmployeeNumber = entity.EmployeeNumber

    };
}