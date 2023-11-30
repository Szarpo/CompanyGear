using CompanyGear.Core.Exceptions;

namespace CompanyGear.Core.ValueObjects;

public sealed record UteNumber
{
    public string Value { get; }

    public UteNumber(string value)
    {
        if (string.IsNullOrWhiteSpace(value) || value.Any(char.IsLetter) && value.Any(char.IsDigit))
            throw new InvalidUteNumberException(value);
        Value = value;
    }

    public static implicit operator string(UteNumber uteNumber) => uteNumber.Value;
    public static implicit operator UteNumber(string value) => new UteNumber(value);
}