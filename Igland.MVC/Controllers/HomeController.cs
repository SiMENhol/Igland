using Igland.MVC.Models.ArbDok;
using Igland.MVC.Models.Home;
using Igland.MVC.Models.Kunder;
using Igland.MVC.Models.Ordre;
using Igland.MVC.Repositories.EF;
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
        [HttpGet]
        public IActionResult Index()
        {
            _logger.LogInformation("Index method called");
            var model = new HomeViewModel();
            model.ArbDokList = _arbdokRepository.GetAll().Select(x => new ArbDokViewModel { ArbDokID = x.ArbDokID, OrdreNummer = x.OrdreNummer, Kunde = x.Kunde, Vinsj = x.Vinsj, HenvendelseMotatt = x.HenvendelseMotatt, AvtaltLevering = x.AvtaltLevering, ProduktMotatt = x.ProduktMotatt, SjekkUtfort = x.SjekkUtfort, AvtaltFerdig = x.AvtaltFerdig, ServiceFerdig = x.ServiceFerdig, AntallTimer = x.AntallTimer, BestillingFraKunde = x.BestillingFraKunde, NotatFraMekaniker = x.NotatFraMekaniker, Status = x.Status }).ToList();
            model.OrdreOversikt = _ordreRepository.GetAll().Select(x => new OrdreViewModel { OrdreNummer = x.OrdreNummer, KundeID = x.KundeID, SerieNummer = x.SerieNummer, VareNavn = x.VareNavn, Status = x.Status }).ToList();
            model.KunderOversitk = _kunderRepository.GetAll().Select(x => new KunderViewModel { KundeID = x.KundeID, KundeNavn = x.KundeNavn }).ToList();
            return View("Index", model);
            
        }

        [HttpGet]
        public IActionResult Privacy()
        {
            _logger.LogInformation("Privacy method called");
            return View("Privacy");
        }
    }
}
