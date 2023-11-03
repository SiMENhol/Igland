using Igland.MVC.Entities;

namespace Igland.MVC.Repositories.IRepo
{
    public interface IOrdreRepository
    {
        void Upsert(OrdreEntity ordre);
        OrdreEntity Get(int id);
        List<OrdreEntity> GetAll();
    }
}