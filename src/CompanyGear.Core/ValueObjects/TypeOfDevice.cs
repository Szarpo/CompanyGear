using CompanyGear.Core.Enums;
using CompanyGear.Core.Exceptions;
namespace CompanyGear.Core.ValueObjects;

public sealed record TypeOfDevice
{
    public TypeOfGearEnum Value { get; }


    public TypeOfDevice(TypeOfGearEnum value)
    {

        Value = value;
    }

    public static implicit operator string(TypeOfDevice typeOfDevice) => typeOfDevice.Value.ToString();
    public static implicit operator TypeOfDevice(string value) => new TypeOfDevice(value);
}