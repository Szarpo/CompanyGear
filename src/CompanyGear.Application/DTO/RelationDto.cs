using CompanyGear.Core.Entities;

namespace CompanyGear.Application.DTO;

public class RelationDto
{
    public Guid Id { get; set; }
    public EmployeeDto? Employee { get; set; }
    public GearDto? Gear { get; set; }
}