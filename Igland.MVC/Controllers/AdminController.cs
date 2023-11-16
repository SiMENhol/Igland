using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Igland.MVC.Models.Account;
using Igland.MVC.Repositories.IRepo;
using Igland.MVC.Models.Users;

namespace Igland.MVC.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class AdminController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IUserRepository userRepository;
        private readonly ILogger _logger;

        public AdminController(UserManager<IdentityUser> userManager, ILoggerFactory loggerFactory, IUserRepository userRepository)
        {
            _userManager = userManager;
            this.userRepository = userRepository;
            _logger = loggerFactory.CreateLogger<AccountController>();
        }

        private UserViewModel CreateUserViewModel(string? email)
        {
            var model = new UserViewModel { Users = userRepository.GetUsers() };

            if (email != null)
            {
                var currentUser = model.Users.FirstOrDefault(x => x.Email == email);

                if (currentUser != null)
                {
                    model.Email = currentUser.Email;
                    model.UserName = currentUser.UserName;
                    model.IsAdmin = userRepository.IsAdmin(currentUser.Email);
                }
            }

            return model;
        }

        [HttpGet]
        public IActionResult Index(string? email)
        {
            _logger.LogInformation("Index method called");
            var model = CreateUserViewModel(email);
            return View(model);
        }

        [HttpGet]
        public IActionResult Oversikt(string? email)
        {
            _logger.LogInformation("Oversikt method called");
            var model = CreateUserViewModel(email);
            return View(model);
        }

        [HttpGet]
        public IActionResult Register(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                var user = new IdentityUser { UserName = model.Email, Email = model.Email, EmailConfirmed = true, LockoutEnabled = false, LockoutEnd = null };
                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    _logger.LogInformation(3, "User created a new account with password.");
                    return RedirectToAction("Oversikt");

                }
            }
            return View(model);
        }
        
        [HttpPost]
        public IActionResult Delete(string email)
        {
            _logger.LogInformation("Delete method called");
            userRepository.Delete(email);
            return RedirectToAction("Oversikt");
        }

        public async Task<IActionResult> MakeUserAdministrator(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);

            if (user != null)
            {
                var result = await _userManager.AddToRoleAsync(user, "Administrator");

                if (result.Succeeded)
                {
                    return RedirectToAction("Oversikt");
                }
                else
                {
                    // Handle the case where adding the user to the role failed
                    return RedirectToAction("Oversikt");
                }
            }
            else
            {
                // Handle the case where the user was not found
                return RedirectToAction("Oversikt");
            }
        }
        
    }
}