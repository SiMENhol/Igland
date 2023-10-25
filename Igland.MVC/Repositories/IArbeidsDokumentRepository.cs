using Igland.MVC.Entities;
using static Igland.MVC.Entities.ArbeidsDokument;

namespace Igland.MVC.Repositories
{
    public class IArbeidsDokumentRepository
    {
        void Upsert(ArbeidsDokument entity);
        ArbeidsDokument Get(int id);
        List<ArbeidsDokument> GetAll();

        // void Update(UserEntity user, List<string> roles);
        // void Add(UserEntity user);
        // List<UserEntity> GetUsers();

        /*
        void Upsert(ArbeidsDokumentEntity entity);
        ArbeidsDokumentEntity Get(int id);
        List<ArbeidsDokumentEntity> GetAll();
        void Update(ArbeidsDokumentEntity arbeidsdokument, List<string> roles);
        void Add(ArbeidsDokumentEntity arbeidsdokument);
        List<ArbeidsDokumentEntity> GetOrdrenummer();
        void Delete(string kunde);

        internal void Upsert(ArbeidsDokumentEntity entity)
        {
            throw new NotImplementedException();
        }
        */
    }
}