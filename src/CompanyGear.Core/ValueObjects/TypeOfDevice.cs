using CompanyGear.Core.Enums;
using CompanyGear.Core.Exceptions;

namespace CompanyGear.Core.ValueObjects;

public sealed record TypeOfDevice
{
    public TypeOfGearEnum Value { get; }


    public TypeOfDevice(TypeOfGearEnum value)
    {
        if (!Enum.IsDefined(typeof(TypeOfGearEnum), value))
        {
            throw new InvalidTypeException(value.ToString());
        }
        Value = value;
    }

    public static implicit operator string(TypeOfDevice typeOfDevice) => typeOfDevice.Value.ToString();
    public static implicit operator TypeOfDevice(int value) => new TypeOfDevice((TypeOfGearEnum)value);
}