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

            // Replace 'GetCurrentUserNameFromDatabase()' with a method that retrieves the username from your repository or service
            string UserName = GetCurrentUserNameFromDatabase();
            string Kunde = GetCurrentKundeFromDatabase();
            int OrdreNummer = GetCurrentOrdreNummerFromDatabase();
            string VinsjType = GetCurrentVinsjTypeFromDatabase();

            var model = new RazorViewModel
            {
                Content = "Hva vil du gjøre idag?",
                AdditionalData = "Kanskje lage link til andre sider som serviceordre? Eller lage en liten meny",
                UserName = UserName, // Pass the retrieved username to the view model
                Kunde = Kunde, // Pass the retrieved Kunde to the view model
                OrdreNummer = OrdreNummer, // Pass the retrieved OrdreNummer to the view model
                VinsjType = VinsjType // Pass the retrieved VinsjType to the view model

            };
            return View("Index", model);
        }

        // Create a method to retrieve the username from your repository or service
        private string GetCurrentUserNameFromDatabase()
        {
            // Replace this with actual code that retrieves the username from the database
            // For example: return _userRepository.GetUserNameById(userId);
            return "USERNAMEFROMDATABSE";
        }

        private string GetCurrentKundeFromDatabase()
        {
            // Replace this with actual code that retrieves Kunde from the database
            // For example: return _userRepository.GetKundeById(userId);
            return "Kunde";
        }

        private int GetCurrentOrdreNummerFromDatabase()
        {
            // Replace this with actual code that retrieves OrdreNummer from the database
            // For example: return _userRepository.GetOrdreNummerById(userId);
            return 12345; // Example value
        }

        private string GetCurrentVinsjTypeFromDatabase()
        {
            // Replace this with actual code that retrieves VinsjType from the database
            // For example: return _userRepository.GetVinsjTypeById(userId);
            return "Vinsjtype";
        }

        [HttpGet]
        public IActionResult Privacy()
        {
            _logger.LogInformation("Privacy method called");
            return View("Privacy");
        }
    }
}
