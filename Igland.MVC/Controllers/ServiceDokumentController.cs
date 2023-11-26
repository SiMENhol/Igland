using Igland.MVC.Entities;
using Igland.MVC.Models.ServiceDokument;
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

        /// <summary>
        /// Get the view of ServiceDokument/Index, based on the CreateServiceDokumentFullViewModel.
        /// </summary>
        /// <returns>A IActionResult View called "Index" with a model called "model".</returns>
        [HttpGet]
        public IActionResult Index()
        {
            _logger.LogInformation("Index method called");

            var model = CreateServiceDokumentFullViewModel();
            return View("Index", model);
        }


  /// <summary>
        /// Get the view of ServiceDokument/Ny, based on the CreateServiceDokumentFullViewModel.
        /// </summary>
        /// <returns>A IActionResult View called "Ny" with a model called "model".</returns>
        [HttpGet]
        public IActionResult Ny()
        {
            _logger.LogInformation("Ny method called");

            var model = CreateServiceDokumentFullViewModel();
            return View("Ny", model);
        }


        /// <summary>
        /// Get the view of ServiceDokument/Rediger, based on the CreateServiceDokumentFullViewModel.
        /// </summary>
        /// <returns>A IActionResult View called "Rediger" with a model called "model".</returns>
        [HttpGet]
        public IActionResult Rediger()
        {
            _logger.LogInformation("Rediger method called");

            var model = CreateServiceDokumentFullViewModel();
            return View("Rediger", model);
        }

      


        /// <summary>
        /// Creates a ServiceDokumentFullViewModel for other methods to use. 
        /// Data from "servicedocRepository" is sent into model called "ServiceDokumentViewModel" with selected instances.
        /// </summary>
        /// <returns>A ServiceDokumentFullViewModel containing list of instances in kunder.</returns>
        private ServiceDokumentFullViewModel CreateServiceDokumentFullViewModel()
        {
            _logger.LogInformation("CreateServiceDokumentFullViewModel method called");
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

        /// <summary>
        /// Post data from where the method is called, based on the ServiceDokumentFullViewModel, creating an ServiceDokument entity that is Upserted to the servicedoc repository.
        /// </summary>
        /// <param name="servicedokument">The ServiceDokumentFullViewModel.</param>
        /// <returns>A IActionResult Redirect to the View called "Index".</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
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
            return Redirect("Index");
        }


        /// <summary>
        /// Delete data from repository servicedoc, based on ServiceSKjemaID.
        /// </summary>
        /// <param name="ServiceSKjemaID">The unique ID for an ServiceDokument</param>
        /// <returns>A IActionResult RedirectToAction  "Index".</returns>
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

