namespace CompanyGear.Core.Exceptions;

public sealed class InvalidNotExistIdException : CustomException
{
    public Guid Id { get; }
    
    public InvalidNotExistIdException(Guid message) : base($"ID: {message} does not exist.")
    {
        Id = message;
    }
}