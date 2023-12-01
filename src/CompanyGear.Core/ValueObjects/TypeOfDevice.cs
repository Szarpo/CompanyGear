using CompanyGear.Core.Exceptions;
namespace CompanyGear.Core.ValueObjects;

public sealed record TypeOfDevice
{
    public string Value { get; }

    public TypeOfDevice(string value)
    {
        if (string.IsNullOrWhiteSpace(value)) throw new InvalidTypeException(value);
            Value = value;

    }

    public static implicit operator string(TypeOfDevice typeOfDevice) => typeOfDevice.Value;
    public static implicit operator TypeOfDevice(string value) => new TypeOfDevice(value);
}