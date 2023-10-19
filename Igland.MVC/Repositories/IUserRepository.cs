using Igland.MVC.Entities;

namespace Igland.MVC.Repositories
{
    public interface IUserRepository
    {

        void Upsert(UserEntity user);
        UserEntity Get(int id);
        List<UserEntity> GetAll();
        void Update(UserEntity user, List<string> roles);
        void Add(UserEntity user);
        List<UserEntity> GetUsers();
        void Delete(string email);
        bool IsAdmin(string email);
    }
}