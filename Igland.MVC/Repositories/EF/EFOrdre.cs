using Igland.MVC.DataAccess;
using Igland.MVC.Entities;
using Igland.MVC.Repositories.IRepo;
using Microsoft.AspNetCore.Identity;

namespace Igland.MVC.Repositories.EF
{
    public class EFOrdre : IOrdreRepository
    {
        private readonly DataContext dataContext;

        public EFOrdre(DataContext dataContext, UserManager<IdentityUser> userManager)
        {
            this.dataContext = dataContext;
        }

        public OrdreEntity Get(int OrdreNummer)
        {
            return dataContext.Ordre.FirstOrDefault(x => x.OrdreNummer == OrdreNummer);
        }

        public List<OrdreEntity> GetAll()
        {
            return dataContext.Ordre.ToList();
        }

        public void Upsert(OrdreEntity Ordre)
        {
            var existing = Get(Ordre.OrdreNummer);
            if (existing != null)
            {
                existing.OrdreNummer = Ordre.OrdreNummer;
                existing.KundeID = Ordre.KundeID;
                existing.SerieNummer = Ordre.SerieNummer;
                existing.VareNavn = Ordre.SerieNummer;
                existing.Status = Ordre.Status;
                dataContext.SaveChanges();
                return;
            }
            Ordre.OrdreNummer = 0;
            dataContext.Add(Ordre);
            dataContext.SaveChanges();
        }
    }
}