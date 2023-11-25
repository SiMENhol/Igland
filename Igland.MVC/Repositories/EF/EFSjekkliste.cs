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



        /// <summary>
        ///  Get an instance from the db table Sjekkliste based on the SjekklisteID.
        /// </summary>
        /// <param name="SjekklisteID">The ID of the desired instance.</param>
        /// <returns>An entity of SjekklisteEntity.</returns>
        public SjekklisteEntity Get(int SjekklisteID)
        {
            return dataContext.Sjekkliste.FirstOrDefault(x => x.SjekklisteID == SjekklisteID);
        }



        /// <summary>
        /// Get all instances from the db table Sjekkliste.
        /// </summary>
        /// <returns>A list of entities of SjekklisteEntity.</returns>
        public List<SjekklisteEntity> GetAll()
        {
            return dataContext.Sjekkliste.ToList();
        }




        /// <summary>
        /// Update/Insert.
        /// If the specified SjekklisteID does not exist in the db, a new instance will be created.
        /// If the specified SjekklisteID does exist in the db, the instance will be updated with the specified values.
        /// </summary>
        /// <param name="sjekkliste">The entity that is to be Upserted to the db.</param>
        public void Upsert(SjekklisteEntity sjekkliste)
        {
            var existing = Get(sjekkliste.SjekklisteID);
            if (existing != null)
            {
                // Update existing entity
                existing.MekanikerNavn = sjekkliste.MekanikerNavn;
                existing.SerieNummer = sjekkliste.SerieNummer;
                existing.Dato = sjekkliste.Dato;
                existing.AntallTimer = sjekkliste.AntallTimer;
                existing.MekanikerKommentar = sjekkliste.MekanikerKommentar;
                existing.OrdreNummer = sjekkliste.OrdreNummer;
                existing.StatusString = sjekkliste.StatusString;
                dataContext.SaveChanges();
                return;
            }

            // Sets ServiceSkjemaID property to zero
            // Insert new entity
            sjekkliste.SjekklisteID = 0;
            dataContext.Add(sjekkliste);
            dataContext.SaveChanges();
        }



        /// <summary>
        /// Delete an instance from the db table Sjekkliste based on the SjekklisteID.
        /// </summary>
        /// <param name="SjekklisteID">The ID of the desired instance.</param>
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