using Igland.MVC.DataAccess;
using Igland.MVC.Entities;
using Microsoft.AspNetCore.Identity;

namespace Igland.MVC.Repositories
{
    public class EFServiceDocsOversikt : IServiceDocsOversikt
    {
        private readonly DataContext dataContext;

        public EFServiceDocsOversikt(DataContext dataContext, UserManager<IdentityUser> userManager)
        {
            this.dataContext = dataContext;
        }

        public ServiceDocs Get(int ServiceSkjemaID)
        {
            return dataContext.Services.FirstOrDefault(x => x.ServiceSkjemaID == ServiceSkjemaID);
        }

        public List<ServiceDocs> GetAll()
        {
            return dataContext.Services.ToList();
        }
    }
}