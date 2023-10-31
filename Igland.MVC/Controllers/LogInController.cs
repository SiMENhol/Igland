using Igland.MVC.Models.Users;
using Igland.MVC.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Igland.MVC.Controllers
{
    public class LogInController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IUserRepository userRepository;
        private readonly ILogger _logger;

        public LogInController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, ILoggerFactory loggerFactory, IUserRepository userRepository)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            this.userRepository = userRepository;
            _logger = loggerFactory.CreateLogger<LogInController>();
        }
        // GET: /Account/Login
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View("Index");
        }

        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(UserViewModel model)
        {
            
                // This doesn't count login failures towards account lockout
                // To enable password failures to trigger account lockout, set lockoutOnFailure: true
                var result = await _signInManager.PasswordSignInAsync(model.Name, model.Password, isPersistent: false, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    _logger.LogInformation(1, "User logged in.");
                    return RedirectToAction(nameof(HomeController.Index), "Home");
                }
                if (result.IsLockedOut)
                {
                    _logger.LogWarning(2, "User account locked out.");
                    ModelState.AddModelError(string.Empty, "User account locked out.");// return View("Lockout");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                   // return View(model);
                }
            

            // If we got this far, something failed, redisplay form
            return View("Index", model);
        }
    }
}

     