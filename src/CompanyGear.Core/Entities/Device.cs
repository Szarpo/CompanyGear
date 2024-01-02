using CompanyGear.Core.ValueObjects;

namespace CompanyGear.Core.Entities;

public class Device
{
    public Guid Id { get; }
    public TypeOfDevice TypeOfDevice { get; private set; }
    public Model Model { get; private set;}
    public SerialNumber SerialNumber { get; private set;}
    public UteNumber UteNumber { get; private set;}

    private Device(Guid id, TypeOfDevice typeOfDevice, string model, string serialNumber, string uteNumber)
    {
        Id = id;
        TypeOfDevice = typeOfDevice;
        Model = model;
        SerialNumber = serialNumber;
        UteNumber = uteNumber;
    }

    public Device() {}

    public static Device Create(TypeOfDevice typeOfDevice, Model model, SerialNumber serialNumber, UteNumber uteNumber)
    {
        return new Device(Guid.NewGuid(), typeOfDevice, model, serialNumber, uteNumber);
    }

    public void Update(TypeOfDevice typeOfDevice, Model model, SerialNumber serialNumber, UteNumber uteNumber)
    {
        TypeOfDevice = typeOfDevice;
        Model = model;
        SerialNumber = serialNumber;
        UteNumber = UteNumber;
    }
    
    
}