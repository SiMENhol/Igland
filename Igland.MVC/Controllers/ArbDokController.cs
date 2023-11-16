using Igland.MVC.Entities;
using Igland.MVC.Models.ArbDok;
using Igland.MVC.Models.Ordre;
using Igland.MVC.Models.Kunder;
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
        private readonly IOrdreRepository _ordreRepository;
        private readonly IKunderRepository _kunderRepository;

        public ArbDokController(ILogger<ArbDokController> logger, IArbDokRepository arbdokRepository, IOrdreRepository ordreRepository, IKunderRepository kunderRepository)
        {
            _logger = logger;
            _arbdokRepository = arbdokRepository;
            _ordreRepository = ordreRepository;
            _kunderRepository = kunderRepository;
        }

        public IActionResult Index()
        {
            var model = new ArbDokFullViewModel();
            model.ArbDokList = _arbdokRepository.GetAll().Select(x => new ArbDokViewModel { ArbDokID = x.ArbDokID, OrdreNummer = x.OrdreNummer, Kunde = x.Kunde, Vinsj = x.Vinsj, HenvendelseMotatt = x.HenvendelseMotatt, AvtaltLevering = x.AvtaltLevering, ProduktMotatt = x.ProduktMotatt, SjekkUtfort = x.SjekkUtfort, AvtaltFerdig = x.AvtaltFerdig, ServiceFerdig = x.ServiceFerdig, AntallTimer = x.AntallTimer, BestillingFraKunde = x.BestillingFraKunde, NotatFraMekaniker = x.NotatFraMekaniker, Status = x.Status }).ToList();
            model.OrdreList = _ordreRepository.GetAll().Select(x => new OrdreViewModel { OrdreNummer = x.OrdreNummer, KundeID = x.KundeID, SerieNummer = x.SerieNummer, VareNavn = x.VareNavn, Status = x.Status}).ToList();
            model.KunderList = _kunderRepository.GetAll().Select(x => new KunderViewModel { KundeID = x.KundeID, KundeNavn = x.KundeNavn }).ToList();
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
            var arbdokEntity = new ArbDok
            {
                ArbDokID = arbdok.UpsertArbDok.ArbDokID,
                OrdreNummer = arbdok.UpsertArbDok.OrdreNummer,
                Kunde = arbdok.UpsertArbDok.Kunde,
                Vinsj = arbdok.UpsertArbDok.Vinsj,
                HenvendelseMotatt = arbdok.UpsertArbDok.HenvendelseMotatt,
                AvtaltLevering = arbdok.UpsertArbDok.AvtaltLevering,
                ProduktMotatt = arbdok.UpsertArbDok.ProduktMotatt,
                SjekkUtfort = arbdok.UpsertArbDok.SjekkUtfort,
                AvtaltFerdig = arbdok.UpsertArbDok.AvtaltFerdig,
                ServiceFerdig = arbdok.UpsertArbDok.ServiceFerdig,
                AntallTimer = arbdok.UpsertArbDok.AntallTimer,
                BestillingFraKunde = arbdok.UpsertArbDok.BestillingFraKunde,
                NotatFraMekaniker = arbdok.UpsertArbDok.NotatFraMekaniker,
                Status = arbdok.UpsertArbDok.Status,
            };
            _arbdokRepository.Upsert(arbdokEntity);

            /*var ordreEntity = new OrdreEntity
            {
                OrdreNummer = arbdok.UpsertOrdre.OrdreNummer,
                KundeID = arbdok.UpsertOrdre.KundeID, // FK
                SerieNummer = arbdok.UpsertOrdre.SerieNummer,
                VareNavn = arbdok.UpsertOrdre.VareNavn,
                Status = arbdok.UpsertOrdre.Status,
            };
            _ordreRepository.Upsert(ordreEntity);

            var kunderEntity = new KunderEntity
            {
                KundeID = arbdok.UpsertKunder.KundeID,
                KundeNavn = arbdok.UpsertKunder.KundeNavn,
            };
            _kunderRepository.Upsert(kunderEntity);*/

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
