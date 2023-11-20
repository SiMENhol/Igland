using Igland.MVC.Entities;
using Microsoft.AspNetCore.Mvc;
using Igland.MVC.Models.Kunder;
using Igland.MVC.Repositories.IRepo;

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
        [HttpGet]
        public IActionResult Index()
        {
            _logger.LogInformation("Index method called");
            var model = CreateKunderFullViewModel();
            return View("Index", model);
        }

        [HttpGet]
        public IActionResult Ny()
        {
            _logger.LogInformation("Index method called");
            var model = CreateKunderFullViewModel();
            return View("Ny", model);
        }
        public IActionResult Rediger()
        {
            _logger.LogInformation("Rediger method called");
            var model = CreateKunderFullViewModel();
            return View("Rediger", model);
        }
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
        [HttpPost]
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
