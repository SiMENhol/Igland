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

        /// <summary>
        /// Get an instance from the db table ServiceDokument based on the ServiceSkjemaID.
        /// </summary>
        /// <param name="ServiceSkjemaID"> The ID of the desired instance.</param>
        /// <returns> An entity of ServiceDokumentEntity</returns>
        public ServiceDokumentEntity Get(int ServiceSkjemaID)
        {
            return dataContext.ServiceDokument.FirstOrDefault(x => x.ServiceSkjemaID == ServiceSkjemaID);
        }

        /// <summary>
        /// Get all instances from the db table ServiceDokument.
        /// </summary>
        /// <returns>A list of entities of ServiceDokumentEntity.</returns>
        public List<ServiceDokumentEntity> GetAll()
        {
            return dataContext.ServiceDokument.ToList();
        }

        /// <summary>
        /// Update/Insert.
        /// If the specified ServiceSkjemaID does not exist in the db, a new instance will be created.
        /// If the specified ServiceSkjemaID does exist in the db, the instance will be updated with the specified values.
        /// </summary>
        /// <param name="serviceSkjema">The entity that is to be Upserted to the db.</param>
        public void Upsert(ServiceDokumentEntity serviceSkjema)
        {
            var existing = Get(serviceSkjema.ServiceSkjemaID);
            if (existing != null)
            {
                // Update existing entity
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

            // Sets ServiceSkjemaID property to zero
            // Insert new entity
            serviceSkjema.ServiceSkjemaID = 0;
            dataContext.Add(serviceSkjema);
            dataContext.SaveChanges();
        }



        /// <summary>
        ///  Delete an instance from the db table ServiceDokument based on the ServiceSkjemaID.
        /// </summary>
        /// <param name="ServiceSkjemaID">The ID of the desired instance.</param>
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
