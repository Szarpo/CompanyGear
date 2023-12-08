using CompanyGear.Application.DTO;
using MediatR;

namespace CompanyGear.Application.Queries;

public record GetEmployeesQuery() : IRequest<IEnumerable<EmployeeDto>>;