namespace CompanyGear.Core.Exceptions;

public class InvalidFullNameException : CustomException
{
    
    public string FullName { get; }
    
    public InvalidFullNameException(string fullname) : base($"Fullname: {fullname} is invalid.")
    {
        FullName = fullname;
    }
}