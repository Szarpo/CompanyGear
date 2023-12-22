using CompanyGear.Core.Enums;
namespace CompanyGear.Core.ValueObjects;

public sealed record TypeOfDevice
{
    public TypeOfGearEnum Value { get; }


    public TypeOfDevice(TypeOfGearEnum value)
    {

        Value = value;
    }

    public static implicit operator string(TypeOfDevice typeOfDevice) => typeOfDevice.Value.ToString();
    public static implicit operator TypeOfDevice(int value) => new TypeOfDevice((TypeOfGearEnum)value);
}