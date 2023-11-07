namespace CompanyGear.Core.Exceptions;

public sealed class InvalidFirstNameException : CustomException
{
    public string FirstName { get; }

    public InvalidFirstNameException(string firstName) : base($"Firstname: {firstName} is invalid.")
    {
        FirstName = firstName;
    }
}