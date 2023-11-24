using Igland.MVC.Entities;
using Igland.MVC.Models.ServiceDokument;
using Igland.MVC.Models.Sjekkliste;
using Igland.MVC.Repositories.IRepo;
using Microsoft.AspNetCore.Mvc;

namespace Igland.MVC.Controllers
{
    public class SjekklisteController : Controller
    {
        private readonly ILogger<SjekklisteController> _logger;

        private readonly ISjekklisteRepository _sjekklisteRepository;

        public SjekklisteController(ILogger<SjekklisteController> logger, ISjekklisteRepository sjekklisteRepository)
        {
            _logger = logger;
            _sjekklisteRepository = sjekklisteRepository;

        }

        [HttpGet]
        public IActionResult Ny()
        {
            var model = new SjekklisteFullViewModel
            {
                UpsertModel = new SjekklisteViewModel
                {
                    AntallTimer = 0,
                    Dato = DateOnly.FromDateTime(DateTime.Today),
                    JobGroups = new List<SjekklisteJobGroupModel> {
                    new SjekklisteJobGroupModel{ Name ="Mekanisk", Jobs=new List<Jobs>{ new Jobs { Name="Sjekk clutch lameller for slitasje", Value=-1 }, new Jobs { Name="Sjekk bremser. Bånd/Pal", Value = -1 }, new Jobs { Name="Sjekk lager for trommel", Value = -1 }, new Jobs { Name="Sjekk PTO og opplagring", Value = -1 }, new Jobs { Name="Sjekk kjedestrammer", Value = -1 }, new Jobs { Name="Sjekk wire", Value = -1 }, new Jobs { Name="Sjekk pinion lager", Value = -1 }, new Jobs { Name="Sjekk kile på kjedehjul", Value = -1 } } },
                    new SjekklisteJobGroupModel{ Name="Hydraulisk", Jobs=new List<Jobs>{ new Jobs { Name = "Sjekk hydraulisk sylinder for lekkasje", Value = -1 }, new Jobs { Name = "Sjekk slanger for skader og lekkasje", Value = -1 }, new Jobs { Name= "Test hydraulikkblokk i testbenk", Value = -1 }, new Jobs { Name = "Skift olje i tank", Value = -1 }, new Jobs { Name = "Skift olje på gir boks", Value = -1 }, new Jobs { Name = "Sjekk Ringsylinder åpne og skift tetninger", Value = -1 }, new Jobs { Name = "Sjekk bremse sylinder åpne og skift tetninger", Value = -1 } } },
                    new SjekklisteJobGroupModel{ Name="Elektro", Jobs=new List<Jobs>{new Jobs { Name = "Sjekk ledningsnett på vinsj", Value = -1 },new Jobs { Name = "Sjekk og test radio", Value = -1 },new Jobs { Name = "Sjekk og test knappekasse", Value = -1 } } },
                    new SjekklisteJobGroupModel{ Name="Trykk settinger", Jobs=new List<Jobs>{new Jobs { Name = "xx- bar", Value = -1 } } },
                    new SjekklisteJobGroupModel{ Name="Funksjons test", Jobs=new List<Jobs>{new Jobs { Name = "Test vinsj og kjør alle funksjoner", Value = -1 }, new Jobs { Name = "Trekkraft KN", Value = -1 }, new Jobs { Name = "Bremse kraft KN", Value = -1 } } },
               },
                    MekanikerNavn = "",
                    MekanikerKommentar = "",
                    SerieNummer = "",
                    SjekklisteID = 1
                }
            };

            return View("Ny", model);
        }

        [HttpGet]
        public IActionResult Rediger()
        {
            var model = new SjekklisteFullViewModel
            {
                UpsertModel = new SjekklisteViewModel
                {
                    AntallTimer = 0,
                    Dato = DateOnly.FromDateTime(DateTime.Today),
                    JobGroups = new List<SjekklisteJobGroupModel> {
                    new SjekklisteJobGroupModel{ Name ="Mekanisk", Jobs=new List<Jobs>{ new Jobs { Name="Sjekk clutch lameller for slitasje", Value=-1 }, new Jobs { Name="Sjekk bremser. Bånd/Pal", Value = -1 }, new Jobs { Name="Sjekk lager for trommel", Value = -1 }, new Jobs { Name="Sjekk PTO og opplagring", Value = -1 }, new Jobs { Name="Sjekk kjedestrammer", Value = -1 }, new Jobs { Name="Sjekk wire", Value = -1 }, new Jobs { Name="Sjekk pinion lager", Value = -1 }, new Jobs { Name="Sjekk kile på kjedehjul", Value = -1 } } },
                    new SjekklisteJobGroupModel{ Name="Hydraulisk", Jobs=new List<Jobs>{ new Jobs { Name = "Sjekk hydraulisk sylinder for lekkasje", Value = -1 }, new Jobs { Name = "Sjekk slanger for skader og lekkasje", Value = -1 }, new Jobs { Name= "Test hydraulikkblokk i testbenk", Value = -1 }, new Jobs { Name = "Skift olje i tank", Value = -1 }, new Jobs { Name = "Skift olje på gir boks", Value = -1 }, new Jobs { Name = "Sjekk Ringsylinder åpne og skift tetninger", Value = -1 }, new Jobs { Name = "Sjekk bremse sylinder åpne og skift tetninger", Value = -1 } } },
                    new SjekklisteJobGroupModel{ Name="Elektro", Jobs=new List<Jobs>{new Jobs { Name = "Sjekk ledningsnett på vinsj", Value = -1 },new Jobs { Name = "Sjekk og test radio", Value = -1 },new Jobs { Name = "Sjekk og test knappekasse", Value = -1 } } },
                    new SjekklisteJobGroupModel{ Name="Trykk settinger", Jobs=new List<Jobs>{new Jobs { Name = "xx- bar", Value = -1 } } },
                    new SjekklisteJobGroupModel{ Name="Funksjons test", Jobs=new List<Jobs>{new Jobs { Name = "Test vinsj og kjør alle funksjoner", Value = -1 }, new Jobs { Name = "Trekkraft KN", Value = -1 }, new Jobs { Name = "Bremse kraft KN", Value = -1 } } },
               },
                    MekanikerNavn = "",
                    MekanikerKommentar = "",
                    SerieNummer = "",
                    SjekklisteID = 1
                }
            };
            model.SjekklisteOversikt = _sjekklisteRepository.GetAll().Select(x => new SjekklisteViewModel { MekanikerNavn = x.MekanikerNavn, SerieNummer = x.SerieNummer, Dato = x.Dato, AntallTimer = x.AntallTimer, MekanikerKommentar = x.MekanikerKommentar, SjekklisteID = x.SjekklisteID, OrdreNummer = x.OrdreNummer, StatusString = x.StatusString }).ToList();

            return View("Rediger", model);
        }

        [HttpGet]
        public IActionResult Index()
        {
            _logger.LogInformation("Index method called");

            var model = new SjekklisteFullViewModel();
            model.SjekklisteOversikt = _sjekklisteRepository.GetAll().Select(x => new SjekklisteViewModel { MekanikerNavn = x.MekanikerNavn, SerieNummer = x.SerieNummer, Dato = x.Dato, AntallTimer = x.AntallTimer, MekanikerKommentar = x.MekanikerKommentar, SjekklisteID = x.SjekklisteID, OrdreNummer = x.OrdreNummer, StatusString = x.StatusString }).ToList();

            return View("Index", model); 
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Post(SjekklisteFullViewModel sjekkliste)
        {
            _logger.LogInformation("Post method called with data: {@sjekkliste}", sjekkliste);
            var statusString = "";
            statusString += sjekkliste.UpsertModel.ClutchLameller + ",";
            statusString += sjekkliste.UpsertModel.Bremser + ",";
            statusString += sjekkliste.UpsertModel.Trommel + ",";
            statusString += sjekkliste.UpsertModel.PTO + ",";
            statusString += sjekkliste.UpsertModel.Kjedestrammer + ",";
            statusString += sjekkliste.UpsertModel.Wire + ",";
            statusString += sjekkliste.UpsertModel.Pinion + ",";
            statusString += sjekkliste.UpsertModel.Kjedehjul + ",";
            statusString += sjekkliste.UpsertModel.Hydraulisksylinder + ",";
            statusString += sjekkliste.UpsertModel.Slanger + ",";
            statusString += sjekkliste.UpsertModel.Hydraulikkblokk + ",";
            statusString += sjekkliste.UpsertModel.Oljetank + ",";
            statusString += sjekkliste.UpsertModel.Oljegir + ",";
            statusString += sjekkliste.UpsertModel.Ringsylinder + ",";
            statusString += sjekkliste.UpsertModel.Bremsesylinder + ",";
            statusString += sjekkliste.UpsertModel.Ledningsnett + ",";
            statusString += sjekkliste.UpsertModel.Testradio + ",";
            statusString += sjekkliste.UpsertModel.Knappekasse + ",";
            statusString += sjekkliste.UpsertModel.Xxbar + ",";
            statusString += sjekkliste.UpsertModel.Testvinsj + ",";
            statusString += sjekkliste.UpsertModel.Trekkraftkn + ",";
            statusString += sjekkliste.UpsertModel.Bremsekraft + ",";

            var entity = new SjekklisteEntity
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
            _sjekklisteRepository.Upsert(entity);
            return Redirect("Index");
        } 
    }
}
