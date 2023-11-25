using Igland.MVC.Entities;
using Microsoft.AspNetCore.Mvc;
using Igland.MVC.Models.Kunder;
using Igland.MVC.Repositories.IRepo;
using Igland.MVC.Repositories.EF;
using Microsoft.AspNetCore.Authorization;

namespace Igland.MVC.Controllers
{
    public class KunderController : Controller
    {
        private readonly ILogger<KunderController> _logger;
        private readonly IKunderRepository _kunderRepository;

        public KunderController(ILogger<KunderController> logger, IKunderRepository kunderRepository)
        {
            _logger = logger;
            _kunderRepository = kunderRepository;
        }

        /// <summary>
        /// Get the view of Kunder/Index, based on the CreateKunderFullViewModel.
        /// </summary>
        /// <returns>A IActionResult View called "Index" with a model called "model".</returns>
        [HttpGet]
        public IActionResult Index()
        {
            _logger.LogInformation("Index method called");
            var model = CreateKunderFullViewModel();
            return View("Index", model);
        }

        /// <summary>
        /// Get the view of Kunder/Ny, based on the CreateKunderFullViewModel.
        /// </summary>
        /// <returns>A IActionResult View called "Ny" with a model called "model".</returns>
        [HttpGet]
        public IActionResult Ny()
        {
            _logger.LogInformation("Ny method called");
            var model = CreateKunderFullViewModel();
            return View("Ny", model);
        }

        /// <summary>
        /// Get the view of Kunder/Rediger, based on the CreateKunderFullViewModel.
        /// </summary>
        /// <returns>A IActionResult View called "Rediger" with a model called "model".</returns>
        [HttpGet]
        public IActionResult Rediger()
        {
            _logger.LogInformation("Rediger method called");
            var model = CreateKunderFullViewModel();
            return View("Rediger", model);
        }

        /// <summary>
        /// Creates a KunderFullViewModel for other methods to use. 
        /// Data from "kunderepository" is sent into model called "KunderViewModel" with selected instances KundeID and KundeNavn.
        /// </summary>
        /// <returns>A KunderFullViewModel containing list of instances in kunder.</returns>
        private KunderFullViewModel CreateKunderFullViewModel()
        {
            _logger.LogInformation("CreateKunderFullViewModel method called");
            return new KunderFullViewModel
            {
                KunderOversikt = _kunderRepository.GetAll()
                    .Select(x => new KunderViewModel
                    {
                        KundeID = x.KundeID,
                        KundeNavn = x.KundeNavn
                    })
                    .ToList()
            };
        }

        /// <summary>
        /// Post data from where the method is called, based on the KunderFullViewModel, creating an entity that is Upserted to the kunderRepository.
        /// </summary>
        /// <param name="kunder">The KunderFullViewModel.</param>
        /// <returns>A IActionResult Redirect to the View called "Index".</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Post(KunderFullViewModel kunder)
        {
            _logger.LogInformation("Upsert method called");
            var entity = new KunderEntity
            {
                KundeID = kunder.UpsertModel.KundeID,
                KundeNavn = kunder.UpsertModel.KundeNavn,

            }; 
            _kunderRepository.Upsert(entity);
            return RedirectToAction("Index");
        }
    }
}
