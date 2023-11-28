using CompanyGear.Core.Exceptions;

namespace CompanyGear.Core.ValueObjects;

public sealed record Model
{
    public string Value { get; }

    public Model(string value)
    {
        if (string.IsNullOrWhiteSpace(value)) throw new InvalidModelException(value);
        Value = value;
    }

    public static implicit operator string(Model model) => model.ToString();
    public static implicit operator Model(string value) => new Model(value);
}