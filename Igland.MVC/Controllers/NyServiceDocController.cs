using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

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
