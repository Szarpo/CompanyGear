using CompanyGear.Core.ValueObjects;

namespace CompanyGear.Core.Exceptions;

public sealed class InvalidUteNumberException : CustomException
{
    public string UteNumber { get; }

    public InvalidUteNumberException(string uteNumber) : base($"UTE Number: {uteNumber} is invalid.")
    {
        UteNumber = uteNumber;
    }
    
}