using CompanyGear.Core.Exceptions;

namespace CompanyGear.Core.ValueObjects;

public sealed record EmployeeNumber
{
    public string Value { get; }

    public EmployeeNumber(string value)
    {
        if (value.Length != 6 )
        {
            throw new InvalidEmployeeNumberException(value);
        }
        
        Value = value;

    }

    public static implicit operator string(EmployeeNumber employeeNumber) => employeeNumber.Value;
    public static implicit operator EmployeeNumber(string value) => new EmployeeNumber(value);
}