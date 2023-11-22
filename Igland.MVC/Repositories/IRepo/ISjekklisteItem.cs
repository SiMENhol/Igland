using Igland.MVC.Entities;

namespace Igland.MVC.Repositories.IRepo
{
    public interface ISjekklisteItemRepository
    {
        void Upsert(SjekklisteItemEntity SjekklisteItemID);
        SjekklisteItemEntity Get(int id);
        List<SjekklisteItemEntity> GetAll();
        void Delete(int SjekklisteItemID);
    }
}
