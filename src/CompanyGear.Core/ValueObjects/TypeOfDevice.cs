using CompanyGear.Core.Enums;
using CompanyGear.Core.Exceptions;

namespace CompanyGear.Core.ValueObjects;

public sealed record TypeOfDevice
{
    public TypeOfDeviceEnum Value { get; }


    public TypeOfDevice(TypeOfDeviceEnum value)
    {
        if (!Enum.IsDefined(typeof(TypeOfDeviceEnum), value))
        {
            throw new InvalidTypeException(value.ToString());
        }
        Value = value;
    }

    public static implicit operator string(TypeOfDevice typeOfDevice) => typeOfDevice.Value.ToString();
    public static implicit operator TypeOfDevice(int value) => new TypeOfDevice((TypeOfDeviceEnum)value);
}