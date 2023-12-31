using CompanyGear.Application.DTO;
using MediatR;

namespace CompanyGear.Application.Queries;

public record GetEmployeeByIdQuery(Guid EmployeeId) : IRequest<EmployeeDto>;
