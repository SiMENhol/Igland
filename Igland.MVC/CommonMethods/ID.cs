using Microsoft.AspNetCore.Mvc.Rendering;

namespace Igland.MVC.CommonMethods
{
    public class ID
    {
        /// <summary>
        /// Retrieves the id from the View that is used to pick the right element from the chosen model's list.
        /// </summary>
        /// <param name="viewContext">Defines the View to retrieve the id from.</param>
        /// <param name="countOfObjectsInList">A number of how many objects there are in the specified list.</param>
        /// <returns>An int relating to the id of the View, which relates to the ID of the chosen model's list object.</returns>
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
