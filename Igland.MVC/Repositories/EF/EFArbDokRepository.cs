using Igland.MVC.DataAccess;
using Igland.MVC.Repositories.IRepo;
using Igland.MVC.Entities;

namespace Igland.MVC.Repositories.EF
{
    public class EFArbDokRepository : IArbDokRepository
    {
        private readonly DataContext dataContext;

        public EFArbDokRepository(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }
        public ArbDok Get(int ArbDokID)
        {
            return dataContext.ArbDok.FirstOrDefault(x => x.ArbDokID == ArbDokID);
        }
        public List<ArbDok> GetAll()
        {
            return dataContext.ArbDok.ToList();
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
                dataContext.SaveChanges();
                return;
            }
            arbdok.ArbDokID = 0;
            dataContext.Add(arbdok);
            dataContext.SaveChanges();
        }
        public void Delete(int ArbDokID)
        {
            ArbDok? arbdok = Get(ArbDokID);
            if (arbdok == null)
                return;
            dataContext.ArbDok.Remove(arbdok);
            dataContext.SaveChanges();
        }
    }
}
