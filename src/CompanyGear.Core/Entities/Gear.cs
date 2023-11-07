namespace CompanyGear.Core.Entities;

public class Gear
{
    public Guid Id { get; }
    public string Type { get; }
    public string Model { get; }
    public string SerialNumber { get; }
    public string UteNumber { get; }

    private Gear(Guid id, string type, string model, string serialNumber, string uteNumber)
    {
        Id = id;
        Type = type;
        Model = model;
        SerialNumber = serialNumber;
        UteNumber = uteNumber;
    }

    public Gear()
    {
        
    }

    public static Gear Create(Guid id, string type, string model, string serialNumber, string uteNumber)
    {
        return new Gear(Guid.NewGuid(), type, model, serialNumber, uteNumber);
    }
}