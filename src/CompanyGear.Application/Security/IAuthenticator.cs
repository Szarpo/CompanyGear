using CompanyGear.Application.DTO;

namespace CompanyGear.Application.Security;

public interface IAuthenticator
{
    JwtDto CreateToken(Guid userId, string role);
}