using CompanyGear.Core.ValueObjects;
using Type = CompanyGear.Core.ValueObjects.Type;

namespace CompanyGear.Core.Entities;

public class Gear
{
    public Guid Id { get; }
    public Type Type { get; }
    public Model Model { get; }
    public SerialNumber SerialNumber { get; }
    public UteNumber UteNumber { get; }

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

    public static Gear Create(string type, string model, string serialNumber, string uteNumber)
    {
        return new Gear(Guid.NewGuid(), type, model, serialNumber, uteNumber);
    }
}