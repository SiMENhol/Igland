using Microsoft.AspNetCore.Authorization;
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
        private readonly ILogger<AdminController> _logger;

        public AdminController(UserManager<IdentityUser> userManager, ILogger<AdminController> logger, IUserRepository userRepository)
        {
            _userManager = userManager;
            this.userRepository = userRepository;
            _logger = logger;
        }

        /// <summary>
        /// Creates a UserViewModel object with a list of all users and the specified user's information if provided.
        /// </summary>
        /// <param name="email">The email address of the user to retrieve information for.</param>
        /// <returns>A UserViewModel object containing the list of users and the specified user's information.</returns>
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

        /// <summary>
        /// Displays the administrator's homepage.
        /// </summary>
        [HttpGet]
        public IActionResult Index(string? email)
        {
            _logger.LogInformation("Index method called");
            var model = CreateUserViewModel(email);
            return View(model);
        }

        /// <summary>
        /// Displays an overview of all users in the system.
        /// </summary>
        [HttpGet]
        public IActionResult Oversikt(string? email)
        {
            _logger.LogInformation("Oversikt method called");
            var model = CreateUserViewModel(email);
            return View(model);
        }

        /// <summary>
        /// Displays the registration page for new users.
        /// </summary>
        [HttpGet]
        public IActionResult Register(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        /// <summary>
        /// Handles the registration process for a new user. Validates user input, creates a new user account, and redirects to the overview page upon successful registration. Otherwise, re-displays the registration page with error messages.
        /// </summary>
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

        /// <summary>
        /// Removes a user from the database based on the provided email address. Logs the action and redirects to the overview page upon successful deletion.
        /// </summary>
        [HttpPost]
        public IActionResult Delete(string email)
        {
            _logger.LogInformation("Delete method called");
            userRepository.Delete(email);
            return RedirectToAction("Oversikt");
        }

        /// <summary>
        /// Promotes a user to the Administrator role by adding them to the corresponding role in the identity system.
        /// </summary>
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