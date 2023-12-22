namespace CompanyGear.Core.Exceptions;

public sealed class InvalidTypeOfDeviceException : CustomException
{
    public string TypeOfDevice { get; }
    public InvalidTypeOfDeviceException(string typeOfDevice) : base($"Type of device: {typeOfDevice} is out of range.")
    {
        TypeOfDevice = typeOfDevice;
    }
}