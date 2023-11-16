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
            var model = new KunderFullViewModel();
            model.KunderOversikt = _kunderRepository.GetAll().Select(x => new KunderViewModel { KundeID = x.KundeID, KundeNavn = x.KundeNavn }).ToList();

            return View("Index", model);
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
