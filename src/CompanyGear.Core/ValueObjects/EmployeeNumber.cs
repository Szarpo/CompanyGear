using CompanyGear.Core.Exceptions;

namespace CompanyGear.Core.ValueObjects;

public sealed record EmployeeNumber
{
    public int Value { get; }

    public EmployeeNumber(int value)
    {
        if (value != 6) throw new InvalidEmployeeNumberException(value);
        
        Value = value;

    }

    public static implicit operator int(EmployeeNumber employeeNumber) => employeeNumber.Value;
    public static implicit operator EmployeeNumber(int value) => new EmployeeNumber(value);
}