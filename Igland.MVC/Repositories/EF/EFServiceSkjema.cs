using Igland.MVC.DataAccess;
using Igland.MVC.Entities;
using Igland.MVC.Repositories.IRepo;
using Microsoft.AspNetCore.Identity;

namespace Igland.MVC.Repositories.EF
{
    public class EFServiceSkjema : IServiceSkjema
    {
        private readonly DataContext dataContext;

        public EFServiceSkjema(DataContext dataContext, UserManager<IdentityUser> userManager)
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