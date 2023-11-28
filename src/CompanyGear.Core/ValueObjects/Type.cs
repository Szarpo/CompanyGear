using CompanyGear.Core.Exceptions;

namespace CompanyGear.Core.ValueObjects;

public sealed record Type
{
    public string Value { get; }

    public Type(string value)
    {
        if (string.IsNullOrWhiteSpace(value)) throw new InvalidTypeException(value);
            Value = value;

    }

    public static implicit operator string(Type type) => type.ToString();
    public static implicit operator Type(string value) => new Type(value);
}