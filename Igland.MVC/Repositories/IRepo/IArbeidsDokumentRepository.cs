using Igland.MVC.Entities;

namespace Igland.MVC.Repositories.IRepo
{
    public interface IArbeidsDokumentRepository
    {
        void Upsert(ArbeidsDokumentEntity user);
        ArbeidsDokumentEntity Get(int id);
        List<ArbeidsDokumentEntity> GetAll();
    }
}