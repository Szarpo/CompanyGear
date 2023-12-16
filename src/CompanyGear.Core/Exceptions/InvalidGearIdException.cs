namespace CompanyGear.Core.Exceptions;

public sealed class InvalidGearIdException : CustomException
{
    public Guid Id { get; }
    
    public InvalidGearIdException(Guid message) : base($"ID: {message} does not exist.")
    {
        Id = message;
    }
}