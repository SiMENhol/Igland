using Igland.MVC.Entities;
using Igland.MVC.Models.ServiceDokument;
using Igland.MVC.Repositories.EF;
using Igland.MVC.Repositories.IRepo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace Igland.MVC.Controllers
{

    public class ServiceDokumentController : Controller
    {
        private readonly ILogger<ServiceDokumentController> _logger;
        private readonly IServiceDokumentRepository _servicedocRepository;

        public ServiceDokumentController(ILogger<ServiceDokumentController> logger, IServiceDokumentRepository servicedocRepository)
        {
            _logger = logger;
            _servicedocRepository = servicedocRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            _logger.LogInformation("Index method called");

            var model = CreateServiceDokumentFullViewModel();
            return View("Index", model);
        }

        public IActionResult Rediger()
        {
            _logger.LogInformation("Rediger method called");

            var model = CreateServiceDokumentFullViewModel();
            return View("Rediger", model);
        }

        [HttpGet]
        public IActionResult Ny()
        {
            _logger.LogInformation("Ny method called");

            var model = CreateServiceDokumentFullViewModel();
            return View("Ny", model);
        }

        private ServiceDokumentFullViewModel CreateServiceDokumentFullViewModel()
        {
            return new ServiceDokumentFullViewModel
            {
                ServiceDokumentOversikt = _servicedocRepository.GetAll()
                    .Select(x => new ServiceDokumentViewModel
                    {
                        ServiceSkjemaID = x.ServiceSkjemaID,
                        OrdreNummer = x.OrdreNummer.GetValueOrDefault(),
                        Aarsmodel = x.Aarsmodel,
                        Garanti = x.Garanti,
                        Reparasjonsbeskrivelse = x.Reparasjonsbeskrivelse,
                        MedgaatteDeler = x.MedgaatteDeler,
                        DeleRetur = x.DeleRetur,
                        ForesendelsesMaate = x.ForesendelsesMaate
                    })
                    .ToList()
            };
        }
        [HttpPost]
        public IActionResult Post(ServiceDokumentFullViewModel servicedokument)
        {
            _logger.LogInformation("Post method called with data: {@servicedokument}", servicedokument);
            var entity = new ServiceDokumentEntity
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
            _servicedocRepository.Upsert(entity);
            return Redirect("index");
        }
       
        [Authorize(Roles = "Administrator")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        
        public IActionResult Delete(int ServiceSKjemaID)
        {
            _logger.LogInformation("Post delete method called");
            _servicedocRepository.Delete(ServiceSKjemaID);
            return RedirectToAction("Index");
        }
    }
}

