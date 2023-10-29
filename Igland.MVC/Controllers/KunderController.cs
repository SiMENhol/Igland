﻿using Igland.MVC.Entities;
using Igland.MVC.Repositories;
using Microsoft.AspNetCore.Mvc;
using Igland.MVC.Models.Kunder;

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
        public IActionResult Index()
        {
            var model = new KunderFullViewModel();
            model.KunderOversikt = _kunderRepository.GetAll().Select(x => new KunderViewModel { KundeID = x.KundeID, KundeNavn = x.KundeNavn }).ToList();

            return View("Index", model);
        }

        [HttpPost]
        public IActionResult Post(KunderFullViewModel kunder)
        {
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