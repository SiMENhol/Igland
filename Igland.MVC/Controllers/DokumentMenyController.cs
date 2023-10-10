using Microsoft.AspNetCore.Mvc;

namespace Igland.MVC.Controllers
{
    public class DokumentMenyController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
