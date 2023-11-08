using Igland.MVC.DataAccess;
using Igland.MVC.Entities;
using Igland.MVC.Repositories.IRepo;
using Microsoft.AspNetCore.Identity;

namespace Igland.MVC.Repositories.EF
{
    public class EFServiceDokument : IServiceDokumentRepository
    {
        private readonly DataContext dataContext;

        public EFServiceDokument(DataContext dataContext, UserManager<IdentityUser> userManager)
        {
            this.dataContext = dataContext;
        }

        public ServiceDokumentEntity Get(int ServiceSkjemaID)
        {
            return dataContext.ServiceDokuments.FirstOrDefault(x => x.ServiceSkjemaID == ServiceSkjemaID);
        }

        public List<ServiceDokumentEntity> GetAll()
        {
            return dataContext.ServiceDokuments.ToList();
        }

        public void Upsert(ServiceDokumentEntity serviceSkjema)
        {
            var existing = Get(serviceSkjema.ServiceSkjemaID);
            if (existing != null)
            {
                existing.OrdreNummer = serviceSkjema.OrdreNummer; //Skal det ikke være ArbeidsDokumentID?
                dataContext.SaveChanges();
                return;
            }
            serviceSkjema.ServiceSkjemaID = 0;
            dataContext.Add(serviceSkjema);
            dataContext.SaveChanges();
        }
    }
}
