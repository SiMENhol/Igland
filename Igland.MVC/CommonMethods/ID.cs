using Microsoft.AspNetCore.Mvc.Rendering;

namespace Igland.MVC.CommonMethods
{
    public class ID
    {
        public int getID(ViewContext viewContext, int countOfObjectsInList)
        {
            int id = Convert.ToInt32(viewContext.RouteData.Values["id"]);
            if (id <= 0 || id > countOfObjectsInList)
            {
                return 0;
            }
            return id - 1;
        }
    }
}
