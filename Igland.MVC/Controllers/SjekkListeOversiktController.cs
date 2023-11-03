using Igland.MVC.Models.ServiceSkjema;
using Igland.MVC.Repositories.IRepo;
using Microsoft.AspNetCore.Mvc;

namespace Igland.MVC.Controllers
{
    public class SjekkListeOversiktController : Controller
    {
 
        private readonly ILogger<ServiceDocsOversiktController> _logger;
        private readonly IServiceSkjema _servicedocRepository;

        public SjekkListeOversiktController(ILogger<ServiceDocsOversiktController> logger, IServiceSkjema servicedocRepository)
        {
            _logger = logger;
            _servicedocRepository = servicedocRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            _logger.LogInformation("Index method called");

            var model = new ServiceSkjemaFullViewModel();
            model.ServiceDocOversikt = _servicedocRepository.GetAll().Select(x => new ServiceSkjemaViewModel { ServiceSkjemaID = x.ServiceSkjemaID, OrdreNummer = x.OrdreNummer.GetValueOrDefault(), Aarsmodel = x.Aarsmodel, Garanti = x.Garanti, Reparasjonsbeskrivelse = x.Reparasjonsbeskrivelse, MedgaatteDeler = x.MedgaatteDeler, DeleRetur = x.DeleRetur, ForesendelsesMaate = x.ForesendelsesMaate }).ToList();

            return View("Index", model);
        }

    }
}
