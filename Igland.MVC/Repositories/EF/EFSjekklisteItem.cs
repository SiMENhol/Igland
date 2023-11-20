using Igland.MVC.DataAccess;
using Igland.MVC.Entities;
using Igland.MVC.Repositories.IRepo;
using Microsoft.AspNetCore.Identity;

namespace Igland.MVC.Repositories.EF
{
    public class EFSjekklisteItem : ISjekklisteItemRepository
    {
        private readonly DataContext dataContext;

        public EFSjekklisteItem(DataContext dataContext, UserManager<IdentityUser> userManager)
        {
            this.dataContext = dataContext;
        }

        public SjekklisteItemEntity Get(int SjekklisteItemID)
        {
            return dataContext.SjekklisteItem.FirstOrDefault(x => x.SjekklisteItemID == SjekklisteItemID);
        }

        public List<SjekklisteItemEntity> GetAll()
        {
            return dataContext.SjekklisteItem.ToList();
        }

        public void Upsert(SjekklisteItemEntity sjekklisteItem)
        {
            var existing = Get(sjekklisteItem.SjekklisteItemID);
            if (existing != null)
            {
                existing.SjekklisteItemID = sjekklisteItem.SjekklisteItemID;
                existing.Jobs = sjekklisteItem.Jobs;
                existing.JobGroups = sjekklisteItem.JobGroups;
                existing.RadioButtonValue = sjekklisteItem.RadioButtonValue;
                dataContext.SaveChanges();
                return;
            }
            sjekklisteItem.SjekklisteItemID = 0;
            dataContext.Add(sjekklisteItem);
            dataContext.SaveChanges();
        }

        public void Delete(int SjekklisteItemID)
        {
            SjekklisteItemEntity? SjekklisteItem = Get(SjekklisteItemID);
            if (SjekklisteItem == null)
                return;
            dataContext.SjekklisteItem.Remove(SjekklisteItem);
            dataContext.SaveChanges();
        }
    }
}