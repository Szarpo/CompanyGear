using CompanyGear.Application.Abstractions;
using CompanyGear.Application.DTO;

namespace CompanyGear.Application.Queries;

public record GetEmployeeByIdQuery : IQuery<EmployeeDto>
{
    public Guid EmployeeId { get; set; }
}