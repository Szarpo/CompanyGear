
namespace CompanyGear.Application.DTO;

public class RelationDto
{
    public Guid Id { get; set; }
    public EmployeeDto? Employee { get; set; }
    public DeviceDto? Gear { get; set; }
    public string? RelationStatus { get; set; }
}