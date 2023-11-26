using Igland.MVC.Models.ArbDok;
using Igland.MVC.Models.Home;
using Igland.MVC.Models.Kunder;
using Igland.MVC.Models.Ordre;
using Igland.MVC.Repositories.IRepo;
using Microsoft.AspNetCore.Mvc;

namespace Igland.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IArbDokRepository _arbdokRepository;
        private readonly IOrdreRepository _ordreRepository;
        private readonly IKunderRepository _kunderRepository;

        public HomeController(ILogger<HomeController> logger, IArbDokRepository arbdokRepository, IOrdreRepository ordreRepository, IKunderRepository kunderRepository)
        {
            _logger = logger;
            _arbdokRepository = arbdokRepository;
            _ordreRepository = ordreRepository;
            _kunderRepository = kunderRepository;
        }


        /// <summary>
        /// Get the view of Home/Index, based on the HomeViewModel, including database data from the arbdok, ordre and kunder repositories.
        /// </summary>
        /// <returns>A IActionResult View called "Index" with a model called "model".</returns>
        [HttpGet]
        public IActionResult Index()
        {
            _logger.LogInformation("Index method called");
            var model = CreateHomeViewModel();
            return View("Index", model);
            
        }

        /// <summary>
        /// Get the view of Home/Privacy.
        /// </summary>
        /// <returns>A IActionResult View called "Privacy".</returns>
        [HttpGet]
        public IActionResult Privacy()
        {
            _logger.LogInformation("Privacy method called");
            return View("Privacy");
        }

        /// <summary>
        /// Creates a HomeViewModel for other methods to use.
        /// </summary>
        /// <returns>A HomeViewModel containing Lists of all instances in the arbdok, ordre and kunde repositories.</returns>
        private HomeViewModel CreateHomeViewModel()
        {
            return new HomeViewModel()
            {
                ArbDokList = _arbdokRepository.GetAll().Select(x => new ArbDokViewModel
                {
                    ArbDokID = x.ArbDokID,
                    OrdreNummer = x.OrdreNummer,
                    Kunde = x.Kunde,
                    Vinsj = x.Vinsj,
                    HenvendelseMotatt = x.HenvendelseMotatt,
                    AvtaltLevering = x.AvtaltLevering,
                    ProduktMotatt = x.ProduktMotatt,
                    SjekkUtfort = x.SjekkUtfort,
                    AvtaltFerdig = x.AvtaltFerdig,
                    ServiceFerdig = x.ServiceFerdig,
                    AntallTimer = x.AntallTimer,
                    BestillingFraKunde = x.BestillingFraKunde,
                    NotatFraMekaniker = x.NotatFraMekaniker,
                    Status = x.Status
                }).ToList(),
                OrdreOversikt = _ordreRepository.GetAll().Select(x => new OrdreViewModel
                {
                    OrdreNummer = x.OrdreNummer,
                    KundeID = x.KundeID,
                    SerieNummer = x.SerieNummer,
                    VareNavn = x.VareNavn,
                    Status = x.Status
                }).ToList(),
                KunderOversikt = _kunderRepository.GetAll().Select(x => new KunderViewModel
                {
                    KundeID = x.KundeID,
                    KundeNavn = x.KundeNavn
                }).ToList()
            };

        }
    }
}
