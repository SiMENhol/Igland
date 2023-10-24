using Igland.MVC.DataAccess;
using Igland.MVC.Entities;
using Igland.MVC.Models;
using Igland.MVC.Models.ServiceDocOversikt;
using Igland.MVC.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;


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

            var model = new HomeFullViewModel();
            model.UserList = _userRepository.GetAll().Select(x => new ServiceDocOversikt { Id = x.Id, Name = x.Name, Email = x.Email}).ToList();

            return View("Index", model);
        }
        [HttpPost]
        public IActionResult Post(HomeFullViewModel user)
        {
            var entity = new UserEntity
            {
                Id = user.UpsertModel.Id,
                Name = user.UpsertModel.Name,
                Email = user.UpsertModel.Email,

            };
            _userRepository.Upsert(entity);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Privacy()
        {
            _logger.LogInformation("Privacy method called");
            return View("Privacy");
        }
    }
}
