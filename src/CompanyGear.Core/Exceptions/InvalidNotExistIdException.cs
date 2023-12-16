namespace CompanyGear.Core.Exceptions;

public sealed class InvalidNotExistIdException : CustomException
{
    public Guid Id { get; }
    
    public InvalidNotExistIdException(Guid id) : base($"ID: {id} does not exist.")
    {
        Id = id;
    }
}