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
          /*  var model = new SjekklisteFullViewModel
            {
                AntallTimer = 0,
                Dato = DateOnly.FromDateTime(DateTime.Today),
                JobGroups = new List<SjekklisteJobGroupModel> {
                    new SjekklisteJobGroupModel {Name ="Mekanisk", Jobs=new List<string>{"Sjekk clutch lameller for slitasje", "Sjekk bremser. Bånd/Pal", "Sjekk lager for trommel", "Sjekk PTO og opplagring", "Sjekk kjedestrammer", "Sjekk wire", "Sjekk pinion lager", "Sjekk kile på kjedehjul"} },
                    new SjekklisteJobGroupModel{ Name="Hydraulisk", Jobs=new List<string>{"Sjekk hydraulisk sylinder for lekkasje","Sjekk slanger for skader og lekkasje", "Test hydraulikkblokk i testbenk", "Skift olje i tank", "Skift olje på gir boks", "Sjekk Ringsylinder åpne og skift tetninger", "Sjekk bremse sylinder åpne og skift tetninger" } },
                    new SjekklisteJobGroupModel{ Name="Elektro", Jobs=new List<string>{"Sjekk ledningsnett på vinsj","Sjekk og test radio","Sjekk og test knappekasse" } },
                    new SjekklisteJobGroupModel{ Name="Trykk settinger", Jobs=new List<string>{"xx- bar" } },
                    new SjekklisteJobGroupModel{ Name="Funksjons test", Jobs=new List<string>{"Test vinsj og kjør alle funksjoner", "Trekkraft KN", "Bremse kraft KN" } },
                },
                MekanikerNavn = "",
                MekanikerKommentar = "",
                SerieNummer = "",
                SjekklisteID = 1
            };
          */
            return View("Ny");
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Save(SjekklisteViewModel model)
        {
            foreach (var jobGroup in model.JobGroups)
            {
                foreach (var job in jobGroup.Jobs)
                {
                    var radioButtonValue = model.RadioButtonValue;
                }
            }
            return View("Index", model);
        }
        [HttpGet]
        public IActionResult Index()
        {
            _logger.LogInformation("Index method called");

            var model = new SjekklisteFullViewModel();
            model.SjekklisteOversikt = _sjekklisteRepository.GetAll().Select(x => new SjekklisteViewModel { MekanikerNavn = x.MekanikerNavn, SerieNummer = x.SerieNummer, Dato = x.Dato, AntallTimer = x.AntallTimer, MekanikerKommentar = x.MekanikerKommentar, SjekklisteID = x.SjekklisteID, OrdreNummer = x.OrdreNummer }).ToList();

            return View("Index", model); 
        }

        public IActionResult Post(SjekklisteFullViewModel sjekkliste)
        {
            _logger.LogInformation("Post method called with data: {@sjekkliste}", sjekkliste);
            var entity = new SjekklisteEntity
            {
                MekanikerNavn = sjekkliste.UpsertModel.MekanikerNavn,
                SerieNummer = sjekkliste.UpsertModel.SerieNummer,
                Dato = sjekkliste.UpsertModel.Dato,
                AntallTimer = sjekkliste.UpsertModel.AntallTimer,
                MekanikerKommentar = sjekkliste.UpsertModel.MekanikerKommentar,
                SjekklisteID = sjekkliste.UpsertModel.SjekklisteID,
                OrdreNummer = sjekkliste.UpsertModel.OrdreNummer,
            };
            _sjekklisteRepository.Upsert(entity);
            return Redirect("index");
        }

    }
}
