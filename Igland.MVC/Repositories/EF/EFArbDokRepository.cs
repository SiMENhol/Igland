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

        /// <summary>
        /// Get an instance from the db table ArbDok based on the ArbDokID.
        /// </summary>
        /// <param name="ArbDokID">The ID of the desired instance.</param>
        /// <returns>An entity of ArbDok.</returns>
        public ArbDok Get(int ArbDokID)
        {
            return dataContext.ArbDok.FirstOrDefault(x => x.ArbDokID == ArbDokID);
        }

        /// <summary>
        /// Get all instances from the db table ArbDok.
        /// </summary>
        /// <returns>A list of entities of ArbDok.</returns>
        public List<ArbDok> GetAll()
        {
            return dataContext.ArbDok.ToList();
        }

        /// <summary>
        /// Update/Insert.
        /// If the specified ArbDokID does not exist in the db, a new instance will be created.
        /// If the specified ArbDokID does exist in the db, the instance will be updated with the specified values.
        /// </summary>
        /// <param name="arbdok">The entity that is to be Upserted to the db.</param>
        /// <returns>Nothing.</returns>
        public void Upsert(ArbDok arbdok)
        {
            var existing = Get(arbdok.ArbDokID);
            if (existing != null)
            {
                existing.OrdreNummer = arbdok.OrdreNummer;
                existing.Uke = arbdok.Uke;
                existing.HenvendelseMotatt = arbdok.HenvendelseMotatt;
                existing.AvtaltLevering = arbdok.AvtaltLevering;
                existing.ProduktMotatt = arbdok.ProduktMotatt;
                existing.SjekkUtfort = arbdok.SjekkUtfort;
                existing.AvtaltFerdig = arbdok.AvtaltFerdig;
                existing.ServiceFerdig = arbdok.ServiceFerdig;
                existing.AntallTimer = arbdok.AntallTimer;
                existing.BestillingFraKunde = arbdok.BestillingFraKunde;
                existing.NotatFraMekaniker = arbdok.NotatFraMekaniker;
                dataContext.SaveChanges();
                return;
            }
            arbdok.ArbDokID = 0;
            dataContext.Add(arbdok);
            dataContext.SaveChanges();
        }

        /// <summary>
        /// Delete an instance from the db table ArbDok based on the ArbDokID.
        /// </summary>
        /// <param name="ArbDokID">The ID of the desired instance.</param>
        /// <returns>Nothing.</returns>
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
