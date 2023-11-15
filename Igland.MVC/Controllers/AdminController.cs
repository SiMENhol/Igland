using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;
using Igland.MVC.Models.Account;
using Igland.MVC.Entities;
using Igland.MVC.Repositories.IRepo;
using Igland.MVC.Models.Users;
using Igland.MVC.Models.ServiceDokument;

namespace Igland.MVC.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class AdminController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IEmailSender _emailSender;
        private readonly IUserRepository userRepository;
        private readonly ILogger _logger;

        public AdminController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, IEmailSender emailSender, ILoggerFactory loggerFactory, IUserRepository userRepository)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSender = emailSender;
            this.userRepository = userRepository;
            _logger = loggerFactory.CreateLogger<AccountController>();
        }
        [HttpGet]
        
        public IActionResult Index(string? email)
        {
            var model = new UserViewModel();
            model.Users = userRepository.GetUsers();
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
            return View(model);
        }
        [HttpGet]
        public IActionResult Oversikt(string? email)
        {
            var model = new UserViewModel();
            model.Users = userRepository.GetUsers();
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
            return View(model);
        }

        //
        // GET: /Account/Register
        [HttpGet]
        public IActionResult Register(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        //
        // POST: /Account/Register
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

                    // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=532713
                    // Send an email with this link
                    //var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    //var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: HttpContext.Request.Scheme);
                    //await _emailSender.SendEmailAsync(model.Email, "Confirm your account",
                    //    "Please confirm your account by clicking this link: <a href=\"" + callbackUrl + "\">link</a>");
                    await _signInManager.SignInAsync(user, isPersistent: false);


                    _logger.LogInformation(3, "User created a new account with password.");

                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }
        
        [HttpPost]
        public IActionResult Delete(string email)
        {
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
                    // User is now in the "Administrator" role
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