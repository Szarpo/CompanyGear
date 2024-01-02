using CompanyGear.Application.DTO;

namespace CompanyGear.Application.Security;

public interface ITokenStorage
{
    void Set(JwtDto jwt);
    JwtDto Get();

    void Remove();
}