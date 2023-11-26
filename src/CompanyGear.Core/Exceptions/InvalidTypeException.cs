namespace CompanyGear.Core.Exceptions;

public class InvalidTypeExeption : CustomException
{
    public InvalidTypeExeption(string message) : base(message)
    {
    }
}