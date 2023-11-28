namespace CompanyGear.Core.Exceptions;

public sealed class InvalidEmployeeNumberException : CustomException
{
    public string EmployeeNumber { get; }

    public InvalidEmployeeNumberException(string employeeNumber) : base($"EmployeeNumber {employeeNumber} is invalid.")
    {
        EmployeeNumber = employeeNumber;
    }
}