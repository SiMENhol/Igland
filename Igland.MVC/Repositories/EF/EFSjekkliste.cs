using Igland.MVC.DataAccess;
using Igland.MVC.Entities;
using Igland.MVC.Repositories.IRepo;
using Microsoft.AspNetCore.Identity;

namespace Igland.MVC.Repositories.EF
{
    public class EFSjekkliste : ISjekklisteRepository
    {
        private readonly DataContext dataContext;

        public EFSjekkliste(DataContext dataContext, UserManager<IdentityUser> userManager)
        {
            this.dataContext = dataContext;
        }

        public SjekklisteEntity Get(int SjekklisteID)
        {
            return dataContext.Sjekkliste.FirstOrDefault(x => x.SjekklisteID == SjekklisteID);
        }

        public List<SjekklisteEntity> GetAll()
        {
            return dataContext.Sjekkliste.ToList();
        }

        public void Upsert(SjekklisteEntity sjekkliste)
        {
            var existing = Get(sjekkliste.SjekklisteID);
            if (existing != null)
            {
                existing.MekanikerNavn = sjekkliste.MekanikerNavn;
                existing.SerieNummer = sjekkliste.SerieNummer;
                existing.Dato = sjekkliste.Dato;
                existing.AntallTimer = sjekkliste.AntallTimer;
                existing.MekanikerKommentar = sjekkliste.MekanikerKommentar;
                existing.OrdreNummer = sjekkliste.OrdreNummer;
                //existing.RadioButtonValues = sjekkliste.RadioButtonValues;
                existing.StatusString = sjekkliste.StatusString;
                dataContext.SaveChanges();
                return;
            }
            sjekkliste.SjekklisteID = 0;
            dataContext.Add(sjekkliste);
            dataContext.SaveChanges();
        }

        public void Delete(int SjekklisteID)
        {
            SjekklisteEntity? Sjekkliste = Get(SjekklisteID);
            if (Sjekkliste == null)
                return;
            dataContext.Sjekkliste.Remove(Sjekkliste);
            dataContext.SaveChanges();
        }
    }
}