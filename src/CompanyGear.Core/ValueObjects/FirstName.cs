using CompanyGear.Core.Exceptions;

namespace CompanyGear.Core.ValueObjects;

public sealed record FirstName
{
    public string Value { get; }

    public FirstName(string value)
    {
        if (string.IsNullOrWhiteSpace(value) || value.Length is > 40 or < 3) throw new InvalidFirstNameException(value);
            Value = value;
        
    }

    public static implicit operator string(FirstName firstName) => firstName.Value;
    public static implicit operator FirstName(string value) => new FirstName(value);
}