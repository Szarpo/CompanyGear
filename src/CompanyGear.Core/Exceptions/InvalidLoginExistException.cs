namespace CompanyGear.Core.Exceptions;

public sealed class InvalidLoginExistException : CustomException
{
    public InvalidLoginExistException() : base("Invalid login")
    {
    }
}