using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Igland.MVC.Controllers
{
    public class KalenderController : Controller
    {
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }
    }
}
