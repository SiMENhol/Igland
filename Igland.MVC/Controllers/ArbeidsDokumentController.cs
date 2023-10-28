using Igland.MVC.Entities;
using Igland.MVC.Models.ArbeidsDokument;
using Igland.MVC.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Igland.MVC.Controllers
{
    public class ArbeidsDokumentController : Controller
    {
        private readonly ILogger<ArbeidsDokumentController> _logger;
        private readonly IArbeidsDokumentRepository _arbeidsdokumentRepository;

        public ArbeidsDokumentController(ILogger<ArbeidsDokumentController> logger, IArbeidsDokumentRepository arbeidsDokumentRepository)
        {
            _logger = logger;
            _arbeidsdokumentRepository = arbeidsDokumentRepository;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Post(ArbeidsDokumentFullViewModel arbeidsdokument)
        {
            var entity = new ArbeidsDokumentEntity
            {
                ArbeidsDokumentID = arbeidsdokument.UpsertModel.ArbeidsDokumentID,
                Ordrenummer = arbeidsdokument.UpsertModel.Ordrenummer,
                Kunde = arbeidsdokument.UpsertModel.Kunde,
                Vinsj = arbeidsdokument.UpsertModel.Vinsj,
                HenvendelseMotatt = arbeidsdokument.UpsertModel.HenvendelseMotatt,
                AvtaltLevering = arbeidsdokument.UpsertModel.AvtaltLevering,
                ProduktMotatt = arbeidsdokument.UpsertModel.ProduktMotatt,
                SjekkUtfort = arbeidsdokument.UpsertModel.SjekkUtfort,
                AvtaltFerdig = arbeidsdokument.UpsertModel.AvtaltFerdig,
                ServiceFerdig = arbeidsdokument.UpsertModel.ServiceFerdig,
                AntallTimer = arbeidsdokument.UpsertModel.AntallTimer,
                BestillingFraKunde = arbeidsdokument.UpsertModel.BestillingFraKunde,
                NotatFraMekaniker = arbeidsdokument.UpsertModel.NotatFraMekaniker,
                Status = arbeidsdokument.UpsertModel.Status,
            };
            _arbeidsdokumentRepository.Upsert(entity);
            return RedirectToAction("Index");
        }
    }
}
