using Igland.MVC.Models.ServiceDokument;
using Igland.MVC.Repositories.IRepo;
using Microsoft.AspNetCore.Mvc;

namespace Igland.MVC.Controllers
{
    public class SjekkListeOversiktController : Controller
    {
 
        private readonly ILogger<ServiceDokumentController> _logger;
        private readonly IServiceSkjema _servicedocRepository;

        public SjekkListeOversiktController(ILogger<ServiceDokumentController> logger, IServiceSkjema servicedocRepository)
        {
            _logger = logger;
            _servicedocRepository = servicedocRepository;
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
