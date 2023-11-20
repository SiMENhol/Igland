using Igland.MVC.Entities;

namespace Igland.MVC.Repositories.IRepo
{
    public interface ISjekklisteRepository
    {
        void Upsert(SjekklisteEntity SjekklisteID);
        SjekklisteEntity Get(int id);
        List<SjekklisteEntity> GetAll();
        void Delete(int SjekklisteID);
    }
}
