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

        /// <summary>
        /// Get an instance from the db table Ordre based on the KundeID.
        /// </summary>
        /// <param name="OrdreNummer">The ID of the desired instance.</param>
        /// <returns>An entity of OrdreEntity.</returns>
        public OrdreEntity Get(int OrdreNummer)
        {
            return dataContext.Ordre.FirstOrDefault(x => x.OrdreNummer == OrdreNummer);
        }

        /// <summary>
        /// Get all instances from the db table Ordre.
        /// </summary>
        /// <returns>A list of entities of OrdreEntity.</returns>
        public List<OrdreEntity> GetAll()
        {
            return dataContext.Ordre.ToList();
        }

        /// <summary>
        /// Update/Insert.
        /// If the specified OrdreNummer does not exist in the db, a new instance will be created.
        /// If the specified OrdreNummer does exist in the db, the instance will be updated with the specified values.
        /// </summary>
        /// <param name="ordre">The entity that is to be Upserted to the db.</param>
        /// <returns>Nothing.</returns>
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