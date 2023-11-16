using Igland.MVC.Entities;
using Igland.MVC.Models.ArbDok;
using Igland.MVC.Repositories.IRepo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Igland.MVC.Controllers
{
    [Authorize]
    public class ArbDokController : Controller
    {
        private readonly ILogger<ArbDokController> _logger;
        private readonly IArbDokRepository _arbdokRepository;

        public ArbDokController(ILogger<ArbDokController> logger, IArbDokRepository arbdokRepository)
        {
            _logger = logger;
            _arbdokRepository = arbdokRepository;
        }

        public IActionResult Index()
        {
            var model = new ArbDokFullViewModel();
            model.ArbDokList = _arbdokRepository.GetAll().Select(x => new ArbDokViewModel { ArbDokID = x.ArbDokID, OrdreNummer = x.OrdreNummer, Kunde = x.Kunde, Vinsj = x.Vinsj, HenvendelseMotatt = x.HenvendelseMotatt, AvtaltLevering = x.AvtaltLevering, ProduktMotatt = x.ProduktMotatt, SjekkUtfort = x.SjekkUtfort, AvtaltFerdig = x.AvtaltFerdig, ServiceFerdig = x.ServiceFerdig, AntallTimer = x.AntallTimer, BestillingFraKunde = x.BestillingFraKunde, NotatFraMekaniker = x.NotatFraMekaniker, Status = x.Status }).ToList();
            return View("Index", model);
        }
        [HttpGet]
        public IActionResult Ny()
        {
            _logger.LogInformation("Index method called");

            var model = new ArbDokFullViewModel();
            model.ArbDokList = _arbdokRepository.GetAll().Select(x => new ArbDokViewModel { ArbDokID = x.ArbDokID, OrdreNummer = x.OrdreNummer, Kunde = x.Kunde, Vinsj = x.Vinsj, HenvendelseMotatt = x.HenvendelseMotatt, AvtaltLevering = x.AvtaltLevering, ProduktMotatt = x.ProduktMotatt, SjekkUtfort = x.SjekkUtfort, AvtaltFerdig = x.AvtaltFerdig, ServiceFerdig = x.ServiceFerdig, AntallTimer = x.AntallTimer, BestillingFraKunde = x.BestillingFraKunde, NotatFraMekaniker = x.NotatFraMekaniker, Status = x.Status }).ToList();

            return View("Ny", model);
        }
        public IActionResult Rediger()
        {
            var model = new ArbDokFullViewModel();
            model.ArbDokList = _arbdokRepository.GetAll().Select(x => new ArbDokViewModel { ArbDokID = x.ArbDokID, OrdreNummer = x.OrdreNummer, Kunde = x.Kunde, Vinsj = x.Vinsj, HenvendelseMotatt = x.HenvendelseMotatt, AvtaltLevering = x.AvtaltLevering, ProduktMotatt = x.ProduktMotatt, SjekkUtfort = x.SjekkUtfort, AvtaltFerdig = x.AvtaltFerdig, ServiceFerdig = x.ServiceFerdig, AntallTimer = x.AntallTimer, BestillingFraKunde = x.BestillingFraKunde, NotatFraMekaniker = x.NotatFraMekaniker, Status = x.Status }).ToList();
            return View("Rediger", model);
        }

        public IActionResult Post(ArbDokFullViewModel arbdok)
        {
            var entity = new ArbDok
            {
                ArbDokID = arbdok.UpsertModel.ArbDokID,
                OrdreNummer = arbdok.UpsertModel.OrdreNummer,
                Kunde = arbdok.UpsertModel.Kunde,
                Vinsj = arbdok.UpsertModel.Vinsj,
                HenvendelseMotatt = arbdok.UpsertModel.HenvendelseMotatt,
                AvtaltLevering = arbdok.UpsertModel.AvtaltLevering,
                ProduktMotatt = arbdok.UpsertModel.ProduktMotatt,
                SjekkUtfort = arbdok.UpsertModel.SjekkUtfort,
                AvtaltFerdig = arbdok.UpsertModel.AvtaltFerdig,
                ServiceFerdig = arbdok.UpsertModel.ServiceFerdig,
                AntallTimer = arbdok.UpsertModel.AntallTimer,
                BestillingFraKunde = arbdok.UpsertModel.BestillingFraKunde,
                NotatFraMekaniker = arbdok.UpsertModel.NotatFraMekaniker,
                Status = arbdok.UpsertModel.Status,
            };
            _arbdokRepository.Upsert(entity);
            return Redirect("index");
        }
        [Authorize(Roles = "Administrator")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int ArbDokID)
        {
            _arbdokRepository.Delete(ArbDokID);
            return RedirectToAction("Index");
        }
    }
}
