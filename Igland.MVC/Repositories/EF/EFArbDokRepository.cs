using Igland.MVC.DataAccess;
using Igland.MVC.Repositories.IRepo;
using Igland.MVC.Entities;

namespace Igland.MVC.Repositories.EF
{
    public class EFArbDokRepository : IArbDokRepository
    {
        private readonly DataContext _dataContext;

        public EFArbDokRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public ArbDok Get(int ArbDokID)
        {
            return _dataContext.ArbDok.FirstOrDefault(x => x.ArbDokID == ArbDokID);
        }
        public List<ArbDok> GetAll()
        {
            return _dataContext.ArbDok.ToList();
        }
        public void Upsert(ArbDok arbdok)
        {
            var existing = Get(arbdok.ArbDokID);
            if (existing != null)
            {
                existing.OrdreNummer = arbdok.OrdreNummer;
                existing.Kunde = arbdok.Kunde;
                existing.Vinsj = arbdok.Vinsj;
                existing.HenvendelseMotatt = arbdok.HenvendelseMotatt;
                existing.AvtaltLevering = arbdok.AvtaltLevering;
                existing.ProduktMotatt = arbdok.ProduktMotatt;
                existing.SjekkUtfort = arbdok.SjekkUtfort;
                existing.AvtaltFerdig = arbdok.AvtaltFerdig;
                existing.ServiceFerdig = arbdok.ServiceFerdig;
                existing.AntallTimer = arbdok.AntallTimer;
                existing.BestillingFraKunde = arbdok.BestillingFraKunde;
                existing.NotatFraMekaniker = arbdok.NotatFraMekaniker;
                existing.Status = arbdok.Status;
                _dataContext.SaveChanges();
                return;
            }
            arbdok.ArbDokID = 0;
            _dataContext.Add(arbdok);
            _dataContext.SaveChanges();
        }
    }
}
