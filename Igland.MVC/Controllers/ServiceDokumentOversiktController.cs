using Igland.MVC.Models.ServiceSkjema;
using Igland.MVC.Repositories.IRepo;
using Microsoft.AspNetCore.Mvc;


namespace Igland.MVC.Controllers
{

    public class ServiceDokumentOversiktController : Controller
    {
        private readonly ILogger<ServiceDokumentController> _logger;
        private readonly IServiceSkjema _servicedocRepository;

        public ServiceDokumentOversiktController(ILogger<ServiceDokumentController> logger, IServiceSkjema servicedokumentRepository)
        {
            _logger = logger;
            _servicedocRepository = servicedokumentRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            _logger.LogInformation("Index method called");

            var model = new ServiceDokumentFullViewModel();
            model.ServiceDocOversikt = _servicedocRepository.GetAll().Select(x => new ServiceDokumentViewModel { ServiceSkjemaID = x.ServiceSkjemaID, OrdreNummer = x.OrdreNummer.GetValueOrDefault(), Aarsmodel = x.Aarsmodel, Garanti = x.Garanti, Reparasjonsbeskrivelse = x.Reparasjonsbeskrivelse, MedgaatteDeler = x.MedgaatteDeler, DeleRetur = x.DeleRetur, ForesendelsesMaate = x.ForesendelsesMaate }).ToList();

            return View("Index", model);
        }

    }
}