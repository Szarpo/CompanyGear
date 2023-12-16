namespace CompanyGear.Core.Exceptions;

public sealed class InvalidGearIdAssignedException : CustomException
{
    public Guid Message { get; }
    
    public InvalidGearIdAssignedException(Guid message) : base($"Gear ID: {message} is already assigned.")
    {
        Message = message;
    }
}