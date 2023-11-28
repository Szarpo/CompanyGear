namespace CompanyGear.Core.Exceptions;

public sealed class InvalidSerialNumberException : CustomException
{
    public string SerialNumber { get; } 
    public InvalidSerialNumberException(string serialNumber) : base($"Serial number: {serialNumber} is invalid.")
    {
        SerialNumber = serialNumber;
    }
}