using Igland.MVC.Models.ArbeidsDokument;
using Igland.MVC.Repositories.IRepo;
using Microsoft.AspNetCore.Mvc;

namespace Igland.MVC.Controllers
{
    public class ArbDocsOversiktController : Controller
    {
        private readonly ILogger<ArbDocsOversiktController> _logger;
        private readonly IArbeidsDokumentRepository _arbeidsdokumentRepository;

        public ArbDocsOversiktController(ILogger<ArbDocsOversiktController> logger, IArbeidsDokumentRepository arbeidsdokumentRepository)
        {
            _logger = logger;
            _arbeidsdokumentRepository = arbeidsdokumentRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            _logger.LogInformation("Index method called");

            var model = new ArbeidsDokumentFullViewModel();
            model.ArbeidsDokOversikt = _arbeidsdokumentRepository.GetAll().Select(x => new ArbeidsDokumentViewModel { ArbeidsDokumentID = x.ArbeidsDokumentID, OrdreNummer = x.OrdreNummer, Kunde = x.Kunde, Vinsj = x.Vinsj, HenvendelseMotatt = x.HenvendelseMotatt, AvtaltLevering = x.AvtaltLevering, ProduktMotatt = x.ProduktMotatt, SjekkUtfort = x.SjekkUtfort, AvtaltFerdig = x.AvtaltFerdig, ServiceFerdig = x.ServiceFerdig, AntallTimer = x.AntallTimer, BestillingFraKunde = x.BestillingFraKunde, NotatFraMekaniker = x.NotatFraMekaniker, Status = x.Status }).ToList();

            return View("Index", model);
        }

    }
}
