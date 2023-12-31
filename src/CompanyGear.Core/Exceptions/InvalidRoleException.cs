namespace CompanyGear.Core.Exceptions;

public sealed class InvalidRoleException : CustomException
{
    public string Role { get; }
    
    public InvalidRoleException(string role) : base($"Role: {role} is out of range.")
    {
        Role = role;
    }
}