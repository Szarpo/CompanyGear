namespace CompanyGear.Core.Exceptions;

public sealed class InvalidLastNameException : CustomException
{
   public string LastName { get; }

   public InvalidLastNameException(string lastName) : base($"Lastname: {lastName} is invalid.")
   {
      LastName = lastName;
   }
}