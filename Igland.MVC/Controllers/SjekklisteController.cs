﻿using Igland.MVC.Entities;
using Igland.MVC.Models.ServiceDokument;
using Igland.MVC.Models.Sjekkliste;
using Igland.MVC.Repositories.IRepo;
using Microsoft.AspNetCore.Mvc;

namespace Igland.MVC.Controllers
{
    public class SjekklisteController : Controller
    {
        private readonly ILogger<SjekklisteController> _logger;

        private readonly ISjekklisteRepository _sjekklisteRepository;
        private readonly ISjekklisteItemRepository _sjekklisteItemRepository;

        public SjekklisteController(ILogger<SjekklisteController> logger, ISjekklisteRepository sjekklisteRepository, ISjekklisteItemRepository sjekklisteItemRepository)
        {
            _logger = logger;
            _sjekklisteRepository = sjekklisteRepository;
            _sjekklisteItemRepository = sjekklisteItemRepository;
        }

        [HttpGet]
        public IActionResult Ny()
        {
            var model = new SjekklisteFullViewModel
            {
                UpsertModel = new SjekklisteViewModel
                {
                    AntallTimer = 0,
                    Dato = DateOnly.FromDateTime(DateTime.Today),
                    JobGroups = new List<SjekklisteJobGroupModel> {
                    new SjekklisteJobGroupModel {Name ="Mekanisk", Jobs=new List<string>{"Sjekk clutch lameller for slitasje", "Sjekk bremser. Bånd/Pal", "Sjekk lager for trommel", "Sjekk PTO og opplagring", "Sjekk kjedestrammer", "Sjekk wire", "Sjekk pinion lager", "Sjekk kile på kjedehjul"} },
                    new SjekklisteJobGroupModel{ Name="Hydraulisk", Jobs=new List<string>{"Sjekk hydraulisk sylinder for lekkasje","Sjekk slanger for skader og lekkasje", "Test hydraulikkblokk i testbenk", "Skift olje i tank", "Skift olje på gir boks", "Sjekk Ringsylinder åpne og skift tetninger", "Sjekk bremse sylinder åpne og skift tetninger" } },
                    new SjekklisteJobGroupModel{ Name="Elektro", Jobs=new List<string>{"Sjekk ledningsnett på vinsj","Sjekk og test radio","Sjekk og test knappekasse" } },
                    new SjekklisteJobGroupModel{ Name="Trykk settinger", Jobs=new List<string>{"xx- bar" } },
                    new SjekklisteJobGroupModel{ Name="Funksjons test", Jobs=new List<string>{"Test vinsj og kjør alle funksjoner", "Trekkraft KN", "Bremse kraft KN" } },
                },
                    MekanikerNavn = "",
                    MekanikerKommentar = "",
                    SerieNummer = "",
                    SjekklisteID = 1
                }
            };
          
            return View("Ny", model);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Save(SjekklisteFullViewModel model)
        {
            foreach (var jobGroup in model.UpsertModel.JobGroups)
            {
                foreach (var job in jobGroup.Jobs)
                {
                    var entity = new SjekklisteItemEntity
                    {
                        // var radioButtonValue = model.UpsertModel.RadioButtonValue;
                        SjekklisteItemID = model.UpsertModel.SjekklisteID,
                        SjekklisteID = model.UpsertModel.SjekklisteID,
                        Jobs = job,
                        JobGroups = jobGroup.Name,
                        RadioButtonValue = model.UpsertModel.RadioButtonValue,
                    };
                    _sjekklisteItemRepository.Upsert(entity);
                }
            }
            return Redirect("Index");
        }

        [HttpGet]
        public IActionResult Index()
        {
            _logger.LogInformation("Index method called");

            var model = new SjekklisteFullViewModel();
            model.SjekklisteOversikt = _sjekklisteRepository.GetAll().Select(x => new SjekklisteViewModel { MekanikerNavn = x.MekanikerNavn, SerieNummer = x.SerieNummer, Dato = x.Dato, AntallTimer = x.AntallTimer, MekanikerKommentar = x.MekanikerKommentar, SjekklisteID = x.SjekklisteID, OrdreNummer = x.OrdreNummer }).ToList();

            return View("Index", model); 
        }

        public IActionResult Post(SjekklisteFullViewModel sjekkliste)
        {
            _logger.LogInformation("Post method called with data: {@sjekkliste}", sjekkliste);
            var entity = new SjekklisteEntity
            {
                MekanikerNavn = sjekkliste.UpsertModel.MekanikerNavn,
                SerieNummer = sjekkliste.UpsertModel.SerieNummer,
                Dato = sjekkliste.UpsertModel.Dato,
                AntallTimer = sjekkliste.UpsertModel.AntallTimer,
                MekanikerKommentar = sjekkliste.UpsertModel.MekanikerKommentar,
                SjekklisteID = sjekkliste.UpsertModel.SjekklisteID,
                OrdreNummer = sjekkliste.UpsertModel.OrdreNummer,
            };
            _sjekklisteRepository.Upsert(entity);

            Save(sjekkliste);

            return Redirect("Index");
        }

    }
}
