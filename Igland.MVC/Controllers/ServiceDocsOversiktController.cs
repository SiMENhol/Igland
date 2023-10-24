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

    public class ServiceDocsOversiktController : Controller
    {
        private readonly ILogger<ServiceDocsOversiktController> _logger;
        private readonly IUserRepository _userRepository;

        public ServiceDocsOversiktController(ILogger<ServiceDocsOversiktController> logger, IUserRepository userRepository)
        {
            _logger = logger;
            _userRepository = userRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            _logger.LogInformation("Index method called");

            var model = new ServiceDocOversiktFullViewModel();
            model.UserList = _userRepository.GetAll().Select(x => new ServiceDocOversikt { Id = x.Id, Name = x.Name, Email = x.Email }).ToList();

            return View("Index", model);
        }
        
    }
}
