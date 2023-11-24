using Igland.MVC.Entities;
using Microsoft.AspNetCore.Mvc;
using Igland.MVC.Repositories.IRepo;
using Igland.MVC.Models.Ordre;
using Igland.MVC.Models.ArbDok;
using Igland.MVC.Models.Sjekkliste;
using Igland.MVC.Models.ServiceDokument;

namespace Igland.MVC.Controllers
{
    public class OrdreController : Controller
    {
        private readonly ILogger<OrdreController> _logger;
        private readonly IOrdreRepository _ordreRepository;
        private readonly IArbDokRepository _arbdokRepository;
        private readonly ISjekklisteRepository _sjekklisteRepository;
        private readonly IServiceDokumentRepository _servicedocRepository;

        public OrdreController(ILogger<OrdreController> logger, IOrdreRepository ordreRepository, IArbDokRepository arbdokRepository, ISjekklisteRepository sjekklisteRepository, IServiceDokumentRepository servicedocRepository)
        {
            _logger = logger;
            _ordreRepository = ordreRepository;
            _arbdokRepository = arbdokRepository;
            _sjekklisteRepository = sjekklisteRepository;
            _servicedocRepository = servicedocRepository;
        }

        /// <summary>
        /// Get the view of Ordre/Index, based on the OrdreFullViewModel, including database data from the ordre repository.
        /// </summary>
        /// <returns>A IActionResult View called "Index" with a model called "model".</returns>
        [HttpGet]
        public IActionResult Index()
        {
            _logger.LogInformation("Index method called");
            var model = CreateOrdreFullViewModel();
            return View("Index", model);
        }

        /// <summary>
        /// Get the view of Ordre/Ny, based on the OrdreFullViewModel, including database data from the ordre repository.
        /// </summary>
        /// <returns>A IActionResult View called "Ny" with a model called "model".</returns>
        [HttpGet]
        public IActionResult Ny()
        {
            _logger.LogInformation("Ny method called");
            var model = CreateOrdreFullViewModel();
            return View("Ny", model);
        }

        /// <summary>
        /// Get the view of Ordre/Rediger, based on the OrdreFullViewModel, including database data from the ordre repository.
        /// </summary>
        /// <returns>A IActionResult View called "Rediger" with a model called "model".</returns>
        [HttpGet]
        public IActionResult Rediger()
        {
            _logger.LogInformation("Rediger method called");
            var model = CreateOrdreFullViewModel();
            return View("Rediger", model);
        }

        /// <summary>
        /// Post data from where the method is called, based on a couple of different models, creating the respective entities that is Upserted to their respected repositories.
        /// The method creates empty entities in the other repositories, connected to the OrdreEntity with OrdreNummer.
        /// </summary>
        /// <param name="ordre">The OrdreFullViewModel</param>
        /// <param name="arbdok">The ArbDokFullViewModel</param>
        /// <param name="sjekkliste">The SjekklisteFullViewModel</param>
        /// <param name="servicedokument">The ServiceDokumentFullViewModel</param>
        /// <param name="sjekklisteController">The Controller of Sjekkliste, used to call an external method</param>
        /// <returns>A IActionResult Redirect to the View called "Index".</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Post(OrdreFullViewModel ordre, ArbDokFullViewModel arbdok, SjekklisteFullViewModel sjekkliste, ServiceDokumentFullViewModel servicedokument, SjekklisteController sjekklisteController)
        {
            _logger.LogInformation("Post method called");
            var entity = new OrdreEntity
            {
                OrdreNummer = ordre.UpsertModel.OrdreNummer,
                KundeID = ordre.UpsertModel.KundeID,
                SerieNummer = ordre.UpsertModel.SerieNummer,
                VareNavn = ordre.UpsertModel.VareNavn,
                Status = ordre.UpsertModel.Status,
            };
            _ordreRepository.Upsert(entity);
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

            var sjekklisteEntity = new SjekklisteEntity
            {
                MekanikerNavn = sjekkliste.UpsertModel.MekanikerNavn,
                SerieNummer = sjekkliste.UpsertModel.SerieNummer,
                Dato = sjekkliste.UpsertModel.Dato,
                AntallTimer = sjekkliste.UpsertModel.AntallTimer,
                MekanikerKommentar = sjekkliste.UpsertModel.MekanikerKommentar,
                SjekklisteID = sjekkliste.UpsertModel.SjekklisteID,
                OrdreNummer = sjekkliste.UpsertModel.OrdreNummer,
                StatusString = sjekklisteController.createStatusString(sjekkliste),
            };
            _sjekklisteRepository.Upsert(sjekklisteEntity);
            var servicedokumentEntity = new ServiceDokumentEntity
            {
                ServiceSkjemaID = servicedokument.UpsertModel.ServiceSkjemaID,
                OrdreNummer = servicedokument.UpsertModel.OrdreNummer,
                Aarsmodel = servicedokument.UpsertModel.Aarsmodel,
                Garanti = servicedokument.UpsertModel.Garanti,
                Reparasjonsbeskrivelse = servicedokument.UpsertModel.Reparasjonsbeskrivelse,
                MedgaatteDeler = servicedokument.UpsertModel.MedgaatteDeler,
                DeleRetur = servicedokument.UpsertModel.DeleRetur,
                ForesendelsesMaate = servicedokument.UpsertModel.ForesendelsesMaate,
            };
            _servicedocRepository.Upsert(servicedokumentEntity);
            
            return Redirect("Index");
        }

        /// <summary>
        /// Creates a OrdreFullViewModel for other methods to use.
        /// </summary>
        /// <returns>A OrdreFullViewModel containing a List of all instances in the ordre repository.</returns>
        private OrdreFullViewModel CreateOrdreFullViewModel()
        {
            return new OrdreFullViewModel
            {
                OrdreOversikt = _ordreRepository.GetAll()
                    .Select(x => new OrdreViewModel
                    {
                        OrdreNummer = x.OrdreNummer,
                        KundeID = x.KundeID,
                        SerieNummer = x.SerieNummer,
                        VareNavn = x.VareNavn,
                        Status = x.Status,
                    })
                    .ToList()
            };
        }
    }
}
