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

        public void Upsert(OrdreEntity ordre)
        {
            var existing = Get(ordre.OrdreNummer);

            if (existing != null)
            {
                // Update existing entity
                existing.OrdreNummer = ordre.OrdreNummer;
                existing.KundeID = ordre.KundeID;
                existing.SerieNummer = ordre.SerieNummer;
                existing.VareNavn = ordre.VareNavn;
                existing.Status = ordre.Status;
                dataContext.SaveChanges();
            }
            else
            {
                // Insert new entity
                dataContext.Add(ordre);
                dataContext.SaveChanges();
            }
        }
    }
}