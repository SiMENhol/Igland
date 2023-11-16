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
            return dataContext.ServiceDokument.FirstOrDefault(x => x.ServiceSkjemaID == ServiceSkjemaID);
        }

        public List<ServiceDokumentEntity> GetAll()
        {
            return dataContext.ServiceDokument.ToList();
        }

        public void Upsert(ServiceDokumentEntity serviceSkjema)
        {
            var existing = Get(serviceSkjema.ServiceSkjemaID);
            if (existing != null)
            {
                existing.OrdreNummer = serviceSkjema.OrdreNummer; 
                existing.Aarsmodel = serviceSkjema.Aarsmodel; 
                existing.Garanti = serviceSkjema.Garanti; 
                existing.Reparasjonsbeskrivelse = serviceSkjema.Reparasjonsbeskrivelse; 
                existing.MedgaatteDeler = serviceSkjema.MedgaatteDeler; 
                existing.DeleRetur = serviceSkjema.DeleRetur; 
                existing.ForesendelsesMaate = serviceSkjema.ForesendelsesMaate ;
                dataContext.SaveChanges();
                return;
            }
            serviceSkjema.ServiceSkjemaID = 0;
            dataContext.Add(serviceSkjema);
            dataContext.SaveChanges();
        }

        public void Delete(int ServiceSkjemaID)
        {
            ServiceDokumentEntity? ServiceSkjema = Get(ServiceSkjemaID);
            if (ServiceSkjema == null)
                return;
            dataContext.ServiceDokument.Remove(ServiceSkjema);
            dataContext.SaveChanges();
        }
    }
}
