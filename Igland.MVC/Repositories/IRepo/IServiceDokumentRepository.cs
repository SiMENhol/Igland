using Igland.MVC.Entities;

namespace Igland.MVC.Repositories.IRepo
{
    public interface IServiceDokumentRepository
    {
        void Upsert(ServiceDokumentEntity ServiceSkjemaID);
        ServiceDokumentEntity Get(int id);
        List<ServiceDokumentEntity> GetAll();
    }
}