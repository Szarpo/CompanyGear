using CompanyGear.Core.ValueObjects;

namespace CompanyGear.Core.Entities;

public class Gear
{
    public Guid Id { get; }
    public TypeOfDevice TypeOfDevice { get; }
    public Model Model { get; }
    public SerialNumber SerialNumber { get; }
    public UteNumber UteNumber { get; }
    public Guid EmployeeId { get; }

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
}