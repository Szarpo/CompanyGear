using CompanyGear.Application.Abstractions;
using CompanyGear.Application.DTO;

namespace CompanyGear.Application.Queries;

public class GetEmployeeWithGearQuery : IQuery<EmployeeWithGearDto>
{
    public Guid EmployeeId { get; set; }
}