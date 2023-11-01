using Igland.MVC.Entities;
using Microsoft.AspNetCore.Mvc;
using Igland.MVC.Repositories.IRepo;
using Igland.MVC.Models.Ordre;

namespace Igland.MVC.Controllers
{
    public class OrdreController : Controller
    {
        private readonly ILogger<OrdreController> _logger;
        private readonly IOrdreRepository _ordreRepository;

        public OrdreController(ILogger<OrdreController> logger, IOrdreRepository ordreRepository)
        {
            _logger = logger;
            _ordreRepository = ordreRepository;
        }
        public IActionResult Index()
        {
            _logger.LogInformation("Index method called");

            var model = new OrdreFullViewModel();
            model.OrdreOversikt = _ordreRepository.GetAll().Select(x => new OrdreViewModel { OrdreNummer = x.OrdreNummer, KundeID = x.KundeID, SerieNummer = x.SerieNummer, VareNavn = x.VareNavn, Status = x.Status, ArbDokument = x.ArbDokument }).ToList();

            return View("Index", model);
        }

        [HttpPost]
        public IActionResult Post(OrdreFullViewModel ordre)
        {
            var entity = new OrdreEntity
            {
                OrdreNummer = ordre.UpsertModel.OrdreNummer,
                KundeID = ordre.UpsertModel.KundeID,
                SerieNummer = ordre.UpsertModel.SerieNummer,
                VareNavn = ordre.UpsertModel.VareNavn,
                Status = ordre.UpsertModel.Status,
                ArbDokument = ordre.UpsertModel.ArbDokument,
            };
            _ordreRepository.Upsert(entity);
            return RedirectToAction("Index");
        }
    }
}
