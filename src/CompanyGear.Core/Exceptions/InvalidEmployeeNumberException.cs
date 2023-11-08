namespace CompanyGear.Core.Exceptions;

public sealed class InvalidEmployeeNumberException : CustomException
{
    public int EmployeeNumber { get; }

    public InvalidEmployeeNumberException(int employeeNumber) : base($"EmployeeNumber {employeeNumber} is invalid.")
    {
        EmployeeNumber = employeeNumber;
    }
}