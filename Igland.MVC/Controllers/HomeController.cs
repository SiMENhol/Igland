using Igland.MVC.DataAccess;
using Igland.MVC.Models;
using Igland.MVC.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Igland.MVC.Controllers
{

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            _logger.LogInformation("Index method called");

            var model = new RazorViewModel
            {
                Content = "Hva vil du gjøre idag?",
                AdditionalData = "Kanskje lage link til andre sider som serviceordre? Eller lage en liten meny",
            };
            return View("Index", model);
        }
    }
}