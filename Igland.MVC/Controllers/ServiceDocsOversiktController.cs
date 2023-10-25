using Igland.MVC.Models.ServiceDocOversikt;
using Igland.MVC.Repositories;
using Microsoft.AspNetCore.Mvc;


namespace Igland.MVC.Controllers
{

    public class ServiceDocsOversiktController : Controller
    {
        private readonly ILogger<ServiceDocsOversiktController> _logger;
        private readonly IServiceDocsOversikt _servicedocRepository;

        public ServiceDocsOversiktController(ILogger<ServiceDocsOversiktController> logger, IServiceDocsOversikt servicedocRepository)
        {
            _logger = logger;
            _servicedocRepository = servicedocRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            _logger.LogInformation("Index method called");

            var model = new ServiceDocOversiktFullViewModel();
            model.ServiceDocOversikt = _servicedocRepository.GetAll().Select(x => new ServiceDocOversiktViewModel { ServiceSkjemaID = x.ServiceSkjemaID, OrdreNummer = x.OrdreNummer.GetValueOrDefault(), Aarsmodel = x.Aarsmodel, Garanti = x.Garanti, Reparasjonsbeskrivelse = x.Reparasjonsbeskrivelse, MedgaatteDeler = x.MedgaatteDeler, DeleRetur = x.DeleRetur, ForesendelsesMaate = x.ForesendelsesMaate }).ToList();

            return View("Index", model);
        }
        
    }
}
