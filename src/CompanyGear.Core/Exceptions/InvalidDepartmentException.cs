namespace CompanyGear.Core.Exceptions;

public sealed class InvalidDepartmentException : CustomException
{
    public string Department { get; }

    public InvalidDepartmentException(string department) : base($"Department {department} is invalid.")
    {
        Department = department;
    }
}