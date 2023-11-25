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
                // Handle the case where the id is not found in the list
                return 0; // Set to the first item as a default
            }
            return id - 1;
        }
    }
}
