namespace CompanyGear.Core.Exceptions;

public sealed class InvalidUserNotExistException : CustomException
{
    public Guid UserId { get; }
    
    public InvalidUserNotExistException(Guid userid) : base($"User: {userid} not exist.")
    {
        UserId = userid;
    }
}