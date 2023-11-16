using Igland.MVC.Models.ServiceDokument;
using Igland.MVC.Models.Sjekkliste;
using Igland.MVC.Repositories.IRepo;
using Microsoft.AspNetCore.Mvc;

namespace Igland.MVC.Controllers
{
    public class SjekklisteController : Controller
    {
        private readonly ILogger<ServiceDokumentController> _logger;

        private readonly ISjekkliste _servicedocRepository;

        public SjekklisteController(ILogger<ServiceDokumentController> logger, ISjekkliste servicedocRepository)
        {
            _logger = logger;
            _servicedocRepository = servicedocRepository;
        }

        [HttpGet]
        public IActionResult Ny()
        {
            var model = new SjekklisteViewModel
            {
                ConsumedHours = 0,
                CreatedDate = new DateOnly(2023, 10, 25),
                JobGroups = new List<SjekklisteJobGroupModel> {
                    new SjekklisteJobGroupModel {Name ="Mekanisk", Jobs=new List<string>{"Sjekk clutch lameller for slitasje", "Sjekk bremser. Bånd/Pal", "Sjekk lager for trommel", "Sjekk PTO og opplagring", "Sjekk kjedestrammer", "Sjekk wire", "Sjekk pinion lager", "Sjekk kile på kjedehjul"} },
                    new SjekklisteJobGroupModel{ Name="Hydraulisk", Jobs=new List<string>{"Sjekk hydraulisk sylinder for lekkasje","Sjekk slanger for skader og lekkasje", "Test hydraulikkblokk i testbenk", "Skift olje i tank", "Skift olje på gir boks", "Sjekk Ringsylinder åpne og skift tetninger", "Sjekk bremse sylinder åpne og skift tetninger" } },
                    new SjekklisteJobGroupModel{ Name="Elektro", Jobs=new List<string>{"Sjekk ledningsnett på vinsj","Sjekk og test radio","Sjekk og test knappekasse" } },
                    new SjekklisteJobGroupModel{ Name="Trykk settinger", Jobs=new List<string>{"xx- bar" } },
                    new SjekklisteJobGroupModel{ Name="Funksjons test", Jobs=new List<string>{"Test vinsj og kjør alle funksjoner", "Trekkraft KN", "Bremse kraft KN" } },
                },
                Mechanic = "",
                MechanicComment = "",
                SerialNumber = "",
                ServiceOrderId = 1
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Save(SjekklisteViewModel model)
        {
            if (ModelState.IsValid)
            {
                var s = "ineedabreakpoint";

            }
            return View("Index", model);
        }
        [HttpGet]
        public IActionResult Index()
        {
            _logger.LogInformation("Index method called");

            var model = new ServiceDokumentFullViewModel();
            model.ServiceDokumentOversikt = _servicedocRepository.GetAll().Select(x => new ServiceDokumentViewModel { ServiceSkjemaID = x.ServiceSkjemaID, OrdreNummer = x.OrdreNummer.GetValueOrDefault(), Aarsmodel = x.Aarsmodel, Garanti = x.Garanti, Reparasjonsbeskrivelse = x.Reparasjonsbeskrivelse, MedgaatteDeler = x.MedgaatteDeler, DeleRetur = x.DeleRetur, ForesendelsesMaate = x.ForesendelsesMaate }).ToList();

            return View("Index", model);
        }
    }
}
