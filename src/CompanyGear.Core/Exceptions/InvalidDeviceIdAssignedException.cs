namespace CompanyGear.Core.Exceptions;

public sealed class InvalidDeviceIdAssignedException : CustomException
{
    public Guid Id { get; }
    
    public InvalidDeviceIdAssignedException(Guid id) : base($"ID: {id} is already assigned.")
    {
        Id = id;
    }
}