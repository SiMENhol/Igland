using Igland.MVC.DataAccess;
using Igland.MVC.Entities;
using Microsoft.AspNetCore.Identity;
using static Igland.MVC.Entities.ArbeidsDokument;

namespace Igland.MVC.Repositories
{
    public class EFArbeidsDokument : IArbeidsDokumentRepository
    {
        private readonly DataContext dataContext;

        public EFArbeidsDokument(DataContext dataContext, UserManager<IdentityUser> userManager)
        {
            this.dataContext = dataContext;
        }

        public ArbeidsDokument Get(int ArbeidsDokumentID)
        {
            return dataContext.arbeidsDokuments.FirstOrDefault(x => x.ArbeidsDokumentID == ArbeidsDokumentID);
        }

        public List<ArbeidsDokument> GetAll()
        {
            return dataContext.arbeidsDokuments.ToList();
        }
    }
}