namespace CompanyGear.Core.Exceptions;

public class InvalidModelException : CustomException
{
    public string Model { get; }
    
    public InvalidModelException(string model) : base($"Model: {model} is invalid.")
    {
        Model = model;
    }
}