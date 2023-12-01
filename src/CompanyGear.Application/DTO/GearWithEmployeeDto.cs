using CompanyGear.Core.Entities;

namespace CompanyGear.Application.DTO;

public class GearWithEmployeeDto
{
     public Guid Id { get; set; }
     public string? TypeOfDevice { get;  set; }
     public string? Model { get;  set;}
     public string? SerialNumber { get;  set;}
     public string? UteNumber { get;  set;}
     public EmployeeDto? Employee { get; set; }
}