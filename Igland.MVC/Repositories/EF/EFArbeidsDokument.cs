using Igland.MVC.DataAccess;
using Igland.MVC.Entities;
using Igland.MVC.Repositories.IRepo;
using Microsoft.AspNetCore.Identity;

namespace Igland.MVC.Repositories.EF
{
    public class EFArbeidsDokument : IArbeidsDokumentRepository
    {
        private readonly DataContext dataContext;

        public EFArbeidsDokument(DataContext dataContext, UserManager<IdentityUser> userManager)
        {
            this.dataContext = dataContext;
        }

        public ArbeidsDokumentEntity Get(int ArbeidsDokumentID)
        {
            return dataContext.ArbeidsDokuments.FirstOrDefault(x => x.ArbeidsDokumentID == ArbeidsDokumentID);
        }

        public List<ArbeidsDokumentEntity> GetAll()
        {
            return dataContext.ArbeidsDokuments.ToList();
        }

        public void Upsert(ArbeidsDokumentEntity arbDokument)
        {
            var existing = Get(arbDokument.ArbeidsDokumentID);
            if (existing != null)
            {
                existing.Ordrenummer = arbDokument.Ordrenummer;
                dataContext.SaveChanges();
                return;
            }
            arbDokument.ArbeidsDokumentID = 0;
            dataContext.Add(arbDokument);
            dataContext.SaveChanges();
        }
    }
}