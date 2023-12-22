using System.Runtime.CompilerServices;
using CompanyGear.Core.Exceptions;

namespace CompanyGear.Core.ValueObjects;

public sealed record Password
{
    public string Value { get; }

    public Password(string value)
    {
        if (string.IsNullOrWhiteSpace(value) || value.Length is > 30 or < 6)
        {
            throw new InvalidPasswordException();
        }

        Value = value;
    }

    public static implicit operator string(Password password) => password.Value;
    public static implicit operator Password(string value) => new Password(value);
}