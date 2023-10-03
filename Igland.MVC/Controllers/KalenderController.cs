using Microsoft.AspNetCore.Mvc;

namespace Igland.MVC.Controllers
{
    public class KalenderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
