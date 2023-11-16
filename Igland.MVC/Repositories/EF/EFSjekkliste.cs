using Igland.MVC.DataAccess;
using Igland.MVC.Entities;
using Igland.MVC.Repositories.IRepo;
using Microsoft.AspNetCore.Identity;

namespace Igland.MVC.Repositories.EF
{
    public class EFSjekkliste : ISjekkliste
    {
        private readonly DataContext dataContext;

        public EFSjekkliste(DataContext dataContext, UserManager<IdentityUser> userManager)
        {
            this.dataContext = dataContext;
        }

        public ServiceDokumentEntity Get(int ServiceSkjemaID)
        {
            return dataContext.ServiceDokument.FirstOrDefault(x => x.ServiceSkjemaID == ServiceSkjemaID);
        }

        public List<ServiceDokumentEntity> GetAll()
        {
            return dataContext.ServiceDokument.ToList();
        }
    }
}