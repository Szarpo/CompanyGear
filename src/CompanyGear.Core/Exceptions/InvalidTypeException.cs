namespace CompanyGear.Core.Exceptions;

public class InvalidTypeException : CustomException
{
    public string TypeOfDevice { get; }
    
    public InvalidTypeException(string typeOfDevice) : base($"Type: {typeOfDevice} is out of range.")
    {
        TypeOfDevice = typeOfDevice;
    }
}