using Igland.MVC.Entities;

namespace Igland.MVC.Repositories.IRepo
{
    public interface IServiceSkjema
    {
        //  void Upsert(ServiceDokumentEntity user);
        ServiceDokumentEntity Get(int id);
        List<ServiceDokumentEntity> GetAll();
    }
}
