using CompanyGear.Core.ValueObjects;

namespace CompanyGear.Core.Entities;

public class User
{
    public Guid Id { get; private set; }
    public Login Login { get; private set; }
    public FullName FullName { get; private set; }
    public Password Password { get; private set; }
    public string Role { get; private set; }
    public DateTime CreatedAt { get; private set; }
    
    private User(Guid id, string login, string fullName, string password, string role, DateTime createdAt)
    {
        Id = id;
        Login = login;
        FullName = fullName;
        Password = password;
        Role = role;
        CreatedAt = createdAt;
    }

    public User()
    {
        
    }

 
}