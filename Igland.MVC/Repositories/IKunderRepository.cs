using Igland.MVC.Entities;

namespace Igland.MVC.Repositories
{
    public interface IKunderRepository
    {
        void Upsert(KunderEntity kunder);
        KunderEntity Get(int id);
        List<KunderEntity> GetAll();
    }
}