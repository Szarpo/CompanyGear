using CompanyGear.Core.Entities;

namespace CompanyGear.Core.Repositories;

public interface IUserRepository
{
     Task SignUp(User user);
     Task<bool> LoginIsExist(string login);
     Task<bool> UserExist(Guid userId);
     Task Update(User user);
     Task<User> GetById(Guid userId);

     Task DeleteUser(User user);
     Task ChangeRole(User user);

     Task<User> GetByLogin(string login);

}