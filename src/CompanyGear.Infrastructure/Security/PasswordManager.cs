using CompanyGear.Application.Security;
using CompanyGear.Core.Entities;
using Microsoft.AspNetCore.Identity;

namespace CompanyGear.Infrastructure.Security;

internal sealed class PasswordManager : IPasswordManager
{

    private readonly IPasswordHasher<User> _passwordHasher;

    public PasswordManager(IPasswordHasher<User> passwordHasher)
    {
        _passwordHasher = passwordHasher;
    }

    public string Password(string password) => _passwordHasher.HashPassword(default!, password);

    public bool ConfirmPassword(string password, string confirmPassword) =>
        _passwordHasher.VerifyHashedPassword(default!, confirmPassword, password) == PasswordVerificationResult.Success;
} 