using Igland.MVC.DataAccess;
using Igland.MVC.Entities;
using Microsoft.AspNetCore.Identity;

namespace Igland.MVC.Repositories
{
    public class EFKunder : IKunderRepository
    {
        private readonly DataContext dataContext;

        public EFKunder(DataContext dataContext, UserManager<IdentityUser> userManager)
        {
            this.dataContext = dataContext;
        }

        public KunderEntity Get(int KundeID)
        {
            return dataContext.Kunder.FirstOrDefault(x => x.KundeID == KundeID);
        }

        public List<KunderEntity> GetAll()
        {
            return dataContext.Kunder.ToList();
        }
        
        public void Upsert(KunderEntity Kunder)
        {
            var existing = Get(Kunder.KundeID);
            if (existing != null)
            {
                existing.KundeNavn= Kunder.KundeNavn;
                dataContext.SaveChanges();
                return;
            }
            Kunder.KundeID = 0;
            dataContext.Add(Kunder);
            dataContext.SaveChanges();
        }
    }
}