using Microsoft.AspNetCore.Mvc;

namespace Igland.MVC.Controllers
{
    public class NyServiceDocController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
