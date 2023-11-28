namespace CompanyGear.Core.Exceptions;

public class InvalidTypeException : CustomException
{
    public string Type { get; }
    
    public InvalidTypeException(string type) : base($"Type: {type} is invalid.")
    {
        Type = type;
    }
}