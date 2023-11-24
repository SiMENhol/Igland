using Igland.MVC.Entities;
using Igland.MVC.Models.ArbDok;
using Igland.MVC.Models.Ordre;
using Igland.MVC.Models.Kunder;
using Igland.MVC.Repositories.IRepo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Igland.MVC.Controllers
{
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

        /// <summary>
        /// Get the view of ArbDok/Index, based on the ArbDokFullViewModel, including database data from the arbdok, ordre and kunder repositories.
        /// </summary>
        /// <returns>A IActionResult View called "Index" with a model called "model".</returns>
        [HttpGet]
        public IActionResult Index()
        {
            _logger.LogInformation("Index method called");
            var model = new ArbDokFullViewModel();
            model.ArbDokList = _arbdokRepository.GetAll().Select(x => new ArbDokViewModel { ArbDokID = x.ArbDokID, OrdreNummer = x.OrdreNummer, Kunde = x.Kunde, Vinsj = x.Vinsj, HenvendelseMotatt = x.HenvendelseMotatt, AvtaltLevering = x.AvtaltLevering, ProduktMotatt = x.ProduktMotatt, SjekkUtfort = x.SjekkUtfort, AvtaltFerdig = x.AvtaltFerdig, ServiceFerdig = x.ServiceFerdig, AntallTimer = x.AntallTimer, BestillingFraKunde = x.BestillingFraKunde, NotatFraMekaniker = x.NotatFraMekaniker, Status = x.Status }).ToList();
            model.OrdreList = _ordreRepository.GetAll().Select(x => new OrdreViewModel { OrdreNummer = x.OrdreNummer, KundeID = x.KundeID, SerieNummer = x.SerieNummer, VareNavn = x.VareNavn, Status = x.Status}).ToList();
            model.KunderList = _kunderRepository.GetAll().Select(x => new KunderViewModel { KundeID = x.KundeID, KundeNavn = x.KundeNavn }).ToList();
            return View("Index", model);
        }

        /// <summary>
        /// Get the view of ArbDok/Ny.
        /// </summary>
        /// <returns>A IActionResult View called "Ny".</returns>
        [HttpGet]
        [ValidateAntiForgeryToken]
        public IActionResult Ny()
        {
            _logger.LogInformation("Ny method called");
            return View("Ny");
        }

        /// <summary>
        /// Get the view of ArbDok/Rediger, based on the ArbDokFullViewModel, including database data from the arbdok, ordre and kunder repositories.
        /// </summary>
        /// <returns>A IActionResult View called "Rediger" with a model called "model".</returns>
        [HttpGet]
        [ValidateAntiForgeryToken]
        public IActionResult Rediger()
        {
            _logger.LogInformation("Rediger method called");
            var model = new ArbDokFullViewModel();
            model.ArbDokList = _arbdokRepository.GetAll().Select(x => new ArbDokViewModel { ArbDokID = x.ArbDokID, OrdreNummer = x.OrdreNummer, Kunde = x.Kunde, Vinsj = x.Vinsj, HenvendelseMotatt = x.HenvendelseMotatt, AvtaltLevering = x.AvtaltLevering, ProduktMotatt = x.ProduktMotatt, SjekkUtfort = x.SjekkUtfort, AvtaltFerdig = x.AvtaltFerdig, ServiceFerdig = x.ServiceFerdig, AntallTimer = x.AntallTimer, BestillingFraKunde = x.BestillingFraKunde, NotatFraMekaniker = x.NotatFraMekaniker, Status = x.Status }).ToList();
            model.OrdreList = _ordreRepository.GetAll().Select(x => new OrdreViewModel { OrdreNummer = x.OrdreNummer, KundeID = x.KundeID, SerieNummer = x.SerieNummer, VareNavn = x.VareNavn, Status = x.Status }).ToList();
            model.KunderList = _kunderRepository.GetAll().Select(x => new KunderViewModel { KundeID = x.KundeID, KundeNavn = x.KundeNavn }).ToList();
            return View("Rediger", model);
        }

        /// <summary>
        /// Post data from where the method is called, based on the ArbDokFullViewModel, creating an ArbDok entity that is Upserted to the arbdok repository.
        /// </summary>
        /// <param name="arbdok">The ArbDokFullViewModel.</param>
        /// <returns>A IActionResult Redirect to the View called "Index".</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Post(ArbDokFullViewModel arbdok)
        {
            _logger.LogInformation("Post method called");
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

            /// Old attempt at updating all three repositories at the same time
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

            return Redirect("Index");
        }

        /// <summary>
        /// Delete data from repository arbdok, based on ArbDokID.
        /// </summary>
        /// <param name="ArbDokID">The unique ID for an ArbDok</param>
        /// <param name="ArbDokID">The unique ID for an ArbDok</param>
        /// <returns>A IActionResult RedirectToAction  "Index".</returns>
        [Authorize(Roles = "Administrator")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int ArbDokID)
        {
            _logger.LogInformation("Post delete method called");
            _arbdokRepository.Delete(ArbDokID);
            return RedirectToAction("Index");
        }
    }
}
