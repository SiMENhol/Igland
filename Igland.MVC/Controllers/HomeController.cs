using Igland.MVC.Entities;
using Igland.MVC.Models.Account;
using Igland.MVC.Repositories.IRepo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace Igland.MVC.Controllers
{

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserRepository _userRepository;

        public HomeController(ILogger<HomeController> logger, IUserRepository userRepository)
        {
            _logger = logger;
            _userRepository = userRepository;
        }
        [HttpGet]
        public IActionResult Index()
        {
            _logger.LogInformation("Index method called");

            var model = new LoginFullViewModel();

            return View("Index", model);
        }

        [HttpGet]
        public IActionResult Privacy()
        {
            _logger.LogInformation("Privacy method called");
            return View("Privacy");
        }
    }
}
