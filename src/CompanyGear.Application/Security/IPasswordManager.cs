namespace CompanyGear.Application.Security;

public interface IPasswordManager
{
    string Password(string password);
    bool ValidatePassword(string password, string confirmPassword);

}