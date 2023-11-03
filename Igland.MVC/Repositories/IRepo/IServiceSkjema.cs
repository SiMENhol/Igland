using Igland.MVC.Entities;

namespace Igland.MVC.Repositories.IRepo
{
    public interface IServiceSkjema
    {

        //  void Upsert(UserEntity user);
        ServiceDocs Get(int id);
        List<ServiceDocs> GetAll();
        // void Update(UserEntity user, List<string> roles);
        // void Add(UserEntity user);
        // List<UserEntity> GetUsers();

    }
}