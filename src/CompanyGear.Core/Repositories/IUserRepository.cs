using CompanyGear.Core.Entities;

namespace CompanyGear.Core.Repositories;

public interface IUserRepository
{
     Task SignUp(User user);
     Task<bool> LoginIsExist(string login);

}