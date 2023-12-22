using System.Security.Cryptography.X509Certificates;
using CompanyGear.Core.Exceptions;

namespace CompanyGear.Core.ValueObjects;

public sealed class Login
{
    public string Value { get; set; }

    public Login(string value)
    {
        if (string.IsNullOrWhiteSpace(value) || value.Length is > 15 or < 3)
        {
            throw new InvalidLoginException(value);
        }

        Value = value;
    }

    public static implicit operator string(Login login) => login.Value;

    public static implicit operator Login(string value) => new Login(value);
}