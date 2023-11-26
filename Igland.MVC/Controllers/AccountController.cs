using Microsoft.AspNetCore.Authorization; //AccountController.cs bruker Microsoft.AspNetCore namespaces som Authorization, Identity og Mvc
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Igland.MVC.Models.Account; //AccountController.cs bruker Account modelen
using Igland.MVC.Repositories.IRepo; //AccountController.cs bruker IRepo namespace

namespace Igland.MVC.Controllers
{
    public class AccountController : Controller //deklarerer klasse med arv fra Controller
    {
        private readonly UserManager<IdentityUser> _userManager; //initialiserer felt _userManager av typen UserManager med parameter fra IdentityUser.
        private readonly SignInManager<IdentityUser> _signInManager; //initialiserer felt _signInManager av typen SignInManager med parameter fra IdentityUser.
        private readonly IUserRepository userRepository; //initialiserer felt userRepository av type IUserRepository
        private readonly ILogger<AccountController> _logger; //initialiserer felt _logger av typen Ilogger<> med AccountController parameter.

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, ILogger<AccountController> logger, IUserRepository userRepository)
        {//konstruerer feltene basert på parametere: userManager, signInManager, logger og userRepository
            _userManager = userManager;
            _signInManager = signInManager;
            this.userRepository = userRepository; //konstruerer instansiert userRepository.
            _logger = logger;
        }

        // GET: /Account/Login
        [HttpGet] //ASP.NET attributt, spesifiserer at denne metoden reager på HTTP Get forespørseler.
        [AllowAnonymous] //ASP.NET attributt, tillater tilgang uten å kreve authorisasjon eller authentikasjon
        public IActionResult Login(string returnUrl = null) //setter returtype for metoden Login til IActionResult. Metoden har parameteren stringreturnUrl, som settes til null om ikke spesifisert som annet
        {
            ViewData["ReturnUrl"] = returnUrl; //setter parameterverdiern i returnUrl i ViewData 
            return View(); //bruker View() til å returnere ViewResult fra IactionResult
        }

        //
        // POST: /Account/Login
        [HttpPost] //spesifiserer at metoden kun responderer til HttpPost spørringer
        [AllowAnonymous] //tillater tilgang uten å kreve autentikasjon eller autorisasjon
        [ValidateAntiForgeryToken] //hinder CSRF angrep ved å validere tokens i spørringer
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl = null) // metoden Login bruker paramaterene LoginViewModel model og string returnUrl (med defaultvalue på null), metoden er asynkron.
        {
            ViewData["ReturnUrl"] = returnUrl;

            if (ModelState.IsValid) //if statement som returnerer true om Modell dataen er valid basert på reglene i LoginViewModel
            {
                // This doesn't count login failures towards account lockout
                // To enable password failures to trigger account lockout, set lockoutOnFailure: true
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false); //lager en variabel av typen result som tester Email, Password, RememberMe og om lockoutOnfailure er false.
                if (result.Succeeded) //if-statement som returnerer true om var result = result.Succeeded
                {
                    _logger.LogInformation(1, "User logged in."); // logger hendelse
                    return RedirectToLocal(returnUrl); //returnerer Urlen til til bruker
                }
                if (result.RequiresTwoFactor) //if-statement som returnerer true om var result = result.RequiresTwoFactor
                {
                    return View(model);
                }
                if (result.IsLockedOut) //if-statement som returnerer true om var result = result.IsLockedOut
                {
                    _logger.LogWarning(2, "User account locked out."); //logger hendelse
                    return View("Lockout");
                }
                else //om ingen if-statements returnerer true utføres else.
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt."); //legger til feilmelding til ModelState
                    return View(model); //returnerer stringen fra feilmeldingen: "Invalid login attempt."
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }


        public async Task<IActionResult> LogOff() //metoden LogOff returnerer en IActionResult og er asynkron
        {
            await _signInManager.SignOutAsync(); //venter asynkront på utføresle av utførelsen av SignOutAsync metoden
            _logger.LogInformation(4, "User logged out."); // logfører strinngen "User logged out." via LogInformation() metoden
            return RedirectToAction(nameof(AccountController.Login)); //returnerer restultatet av RedirectToAction() metoden utført på navnet på login handilingen i AccountController
        }

        private IActionResult RedirectToLocal(string returnUrl) //metoden RedirectToLocal() har parameteren string returnUrl og returnerer IactionResult
        {
            if (Url.IsLocalUrl(returnUrl))  //if-statement som sjekker om Urlen er en lokal applikajson Url
            {
                return Redirect(returnUrl); //returnerer lokal applikasjonUrl
            }
            else //om returnUrl ikke er lokal url utføres handling
            {
                return RedirectToAction(nameof(HomeController.Index), "Home"); //returnerer resultatet av RedirectToAction() utført på navnet til Index handlingen utført på HomeController. Redirigerer bruker til hjem
            }
        }
    }
}
             
