namespace CompanyGear.Core.ValueObjects;

public sealed record FullName
{
    public string Value { get; }

    public FullName(string value)
    {
        if (string.IsNullOrWhiteSpace(value) || value.Length is > 30 or < 5)
        {
            
        }

        Value = value;
    }

    public static implicit operator string(FullName fullName) => fullName.Value;

    public static implicit operator FullName(string value) => new FullName(value);

}