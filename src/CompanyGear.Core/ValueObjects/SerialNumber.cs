using CompanyGear.Core.Exceptions;

namespace CompanyGear.Core.ValueObjects;

public sealed record SerialNumber
{
    public string Value { get; }

    public SerialNumber(string value)
    {
        if (string.IsNullOrWhiteSpace(value)) throw new InvalidSerialNumberException(value);
        Value = value;
    }

    public static implicit operator string(SerialNumber serialNumber) => serialNumber.Value;
    public static implicit operator SerialNumber(string value) => new SerialNumber(value);
}