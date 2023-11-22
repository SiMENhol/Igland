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
        public IActionResult Index()
        {
            _logger.LogInformation("Index method called");

            var model = CreateOrdreFullViewModel();
            return View("Index", model);
        }
        [HttpGet]
        public IActionResult Ny()
        {
            _logger.LogInformation("Index method called");

            var model = CreateOrdreFullViewModel();
            return View("Ny", model);
        }
        public IActionResult Rediger()
        {
            var model = CreateOrdreFullViewModel();
            return View("Rediger", model);
        }

        [HttpPost]
        public IActionResult Post(OrdreFullViewModel ordre, ArbDokFullViewModel arbdok, SjekklisteFullViewModel sjekkliste, ServiceDokumentFullViewModel servicedokument)
        {
            _logger.LogInformation("Post method called");
            var entity = new OrdreEntity
            {
                OrdreNummer = ordre.UpsertModel.OrdreNummer,
                KundeID = ordre.UpsertModel.KundeID,
                SerieNummer = ordre.UpsertModel.SerieNummer,
                VareNavn = ordre.UpsertModel.VareNavn,
                Status = ordre.UpsertModel.Status,
                ArbDokument = ordre.UpsertModel.ArbDokument,
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
            _logger.LogInformation("Post method called with data: {@sjekkliste}", sjekkliste);
            var statusString = "";
            statusString += sjekkliste.UpsertModel.ClutchLameller + ",";
            statusString += sjekkliste.UpsertModel.Bremser + ",";
            statusString += sjekkliste.UpsertModel.Trommel + ",";

            var sjekklisteEntity = new SjekklisteEntity
            {
                MekanikerNavn = sjekkliste.UpsertModel.MekanikerNavn,
                SerieNummer = sjekkliste.UpsertModel.SerieNummer,
                Dato = sjekkliste.UpsertModel.Dato,
                AntallTimer = sjekkliste.UpsertModel.AntallTimer,
                MekanikerKommentar = sjekkliste.UpsertModel.MekanikerKommentar,
                SjekklisteID = sjekkliste.UpsertModel.SjekklisteID,
                OrdreNummer = sjekkliste.UpsertModel.OrdreNummer,
                StatusString = statusString,
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
                        ArbDokument = x.ArbDokument
                    })
                    .ToList()
            };
        }
    }
}
