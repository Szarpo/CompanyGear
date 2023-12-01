using CompanyGear.Core.ValueObjects;

namespace CompanyGear.Core.Entities;

public class Gear
{
    public Guid Id { get; }
    public TypeOfDevice TypeOfDevice { get; private set; }
    public Model Model { get; private set;}
    public SerialNumber SerialNumber { get; private set;}
    public UteNumber UteNumber { get; private set;}
    public Guid EmployeeId { get; private set; }
    public Employee Employee { get; private set; }

    private Gear(Guid id, string typeOfDevice, string model, string serialNumber, string uteNumber)
    {
        Id = id;
        TypeOfDevice = typeOfDevice;
        Model = model;
        SerialNumber = serialNumber;
        UteNumber = uteNumber;
    }

    public Gear() {}

    public static Gear Create(TypeOfDevice typeOfDevice, Model model, SerialNumber serialNumber, UteNumber uteNumber)
    {
        return new Gear(Guid.NewGuid(), typeOfDevice, model, serialNumber, uteNumber);
    }

    public void AssignmentGearToEmployee(Guid employeeId)
    {
        EmployeeId = employeeId;
    }
    
}