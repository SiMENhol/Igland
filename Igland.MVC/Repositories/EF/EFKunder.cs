using Igland.MVC.DataAccess;
using Igland.MVC.Entities;
using Igland.MVC.Repositories.IRepo;
using Microsoft.AspNetCore.Identity;

namespace Igland.MVC.Repositories.EF
{
    public class EFKunder : IKunderRepository
    {
        private readonly DataContext dataContext;

        public EFKunder(DataContext dataContext, UserManager<IdentityUser> userManager)
        {
            this.dataContext = dataContext;
        }

        /// <summary>
        /// Get an instance from the db table Kunder based on the KundeID.
        /// </summary>
        /// <param name="KundeID">The ID of the desired instance.</param>
        /// <returns>An entity of KunderEntity.</returns>
        public KunderEntity Get(int KundeID)
        {
            return dataContext.Kunder.FirstOrDefault(x => x.KundeID == KundeID);
        }

        /// <summary>
        /// Get all instances from the db table Kunder.
        /// </summary>
        /// <returns>A list of entities of KunderEntity.</returns>
        public List<KunderEntity> GetAll()
        {
            return dataContext.Kunder.ToList();
        }

        /// <summary>
        /// Update/Insert.
        /// If the specified KundeID does not exist in the db, a new instance will be created.
        /// If the specified KundeID does exist in the db, the instance will be updated with the specified values.
        /// </summary>
        /// <param name="Kunder">The entity that is to be Upserted to the db.</param>
        /// <returns>Nothing.</returns>
        public void Upsert(KunderEntity Kunder)
        {
            var existing = Get(Kunder.KundeID);
            if (existing != null)
            {
                existing.KundeNavn = Kunder.KundeNavn;
                dataContext.SaveChanges();
                return;
            }
            Kunder.KundeID = 0;
            dataContext.Add(Kunder);
            dataContext.SaveChanges();
        }
    }
}