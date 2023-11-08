using Igland.MVC.Entities;

namespace Igland.MVC.Repositories.IRepo
{
    public interface IArbDokRepository
    {
        void Upsert(ArbDok arbdok);
        ArbDok Get(int ArbDokID);
        List<ArbDok> GetAll();

    }
}
