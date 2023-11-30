using CompanyGear.Core.Exceptions;
namespace CompanyGear.Core.ValueObjects;

public sealed record LastName
{
    public string Value { get; }

    public LastName(string value)
    {
        if (string.IsNullOrWhiteSpace(value) || value.Length is > 20 or < 3) throw new InvalidLastNameException(value);
        Value = value;
        
    }

    public static implicit operator string(LastName lastName) => lastName.Value;
    public static implicit operator LastName(string value) => new LastName(value);
}