using Igland.MVC.Entities;

namespace Igland.MVC.Repositories.IRepo
{
    public interface IUserRepository
    {

        void Update(UserEntity user, List<string> roles);
        List<UserEntity> GetUsers();
        void Delete(string email);
        bool IsAdmin(string email);
    }
}