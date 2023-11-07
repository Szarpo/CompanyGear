using CompanyGear.Core.Exceptions;

namespace CompanyGear.Core.ValueObjects;

public sealed record Department
{
    public string Value { get; }

    public Department(string value)
    {
        if (string.IsNullOrWhiteSpace(value) || value.Length is > 7 or < 2) throw new InvalidDepartmentException(value);

        Value = value;
    }

    public static implicit operator string(Department department) => department.Value;
    public static implicit operator Department(string value) => new Department(value);
}