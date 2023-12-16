namespace CompanyGear.Core.Exceptions;

public sealed class InvalidGearIdAssignedException : CustomException
{
    public Guid Id { get; }
    
    public InvalidGearIdAssignedException(Guid id) : base($"ID: {id} is already assigned.")
    {
        Id = id;
    }
}