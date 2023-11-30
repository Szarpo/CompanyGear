namespace CompanyGear.Application.DTO;

public class GearDto
{
    public Guid Id { get; set; }
    public string TypeOfDevice { get; set; }
    public string Model { get; set; }
    public string SerialNumber { get; set; }
    public string UteNumber { get; set; }
    public Guid EmployeeId { get; set; }
}