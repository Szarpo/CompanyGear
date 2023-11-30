using CompanyGear.Core.Entities;

namespace CompanyGear.Application.DTO;

public class EmployeeWithGearDto
{
    public Guid EmployeeId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }    
    public string EmployeeNumber { get; set; }
    public string Department { get; set; }
    
     public GearDto Gear { get; set; }
}