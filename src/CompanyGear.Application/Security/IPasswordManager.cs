namespace CompanyGear.Application.Security;

public interface IPasswordManager
{
    string Password(string password);
    bool ConfirmPassword(string password, string confirmPassword);

}