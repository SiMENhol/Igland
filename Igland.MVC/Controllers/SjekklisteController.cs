﻿using Igland.MVC.Entities;
using Igland.MVC.Models.Sjekkliste;
using Igland.MVC.Repositories.IRepo;
using Microsoft.AspNetCore.Mvc;
using Igland.MVC.CommonMethods;

namespace Igland.MVC.Controllers
{
    public class SjekklisteController : Controller
    {
        private readonly ILogger<SjekklisteController> _logger;
        private readonly ISjekklisteRepository _sjekklisteRepository;

        public SjekklisteController(ILogger<SjekklisteController> logger, ISjekklisteRepository sjekklisteRepository)
        {
            _logger = logger;
            _sjekklisteRepository = sjekklisteRepository;
        }

        /// <summary>
        /// Get the view of Sjekkliste/Ny, based on the SjekkListeFullViewModel, including database data from the sjekkliste repository.
        /// </summary>
        /// <returns>A IActionResult View called "Index" with a model called "model".</returns>
        [HttpGet]
        public IActionResult Index()
        {
            _logger.LogInformation("Index method called");
            var model = CreateSjekkListeFullViewModel();
            return View("Index", model);
        }

        /// <summary>
        /// Get the view of Sjekkliste/Index, based on the SjekkListeFullViewModel, including database data from the sjekkliste repository.
        /// </summary>
        /// <returns>A IActionResult View called "Ny" with a model called "model".</returns>
        [HttpGet]
        public IActionResult Ny()
        {
            _logger.LogInformation("Ny method called");
            var model = CreateSjekkListeFullViewModel();
            return View("Ny", model);
        }

        /// <summary>
        /// Get the view of Sjekkliste/Rediger, based on the SjekkListeFullViewModel, including database data from the sjekkliste repository.
        /// </summary>
        /// <returns>A IActionResult View called "Rediger" with a model called "model".</returns>
        [HttpGet]
        public IActionResult Rediger()
        {
            _logger.LogInformation("Rediger method called");
            var model = CreateSjekkListeFullViewModel();
            return View("Rediger", model);
        }

        /// <summary>
        /// Post data from where the method is called, based on the SjekklisteFullViewModel, including database data from the sjekkliste repositoriy.
        /// </summary>
        /// <param name="sjekkliste">The SjekklisteFullViewModel.</param>
        /// <returns>A IActionResult Redirect to the View called "Index".</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Post(SjekklisteFullViewModel sjekkliste)
        {
            _logger.LogInformation("Post method called with data: {@sjekkliste}", sjekkliste);
            SjekklisteRadioButtonValues radiobuttons = new SjekklisteRadioButtonValues();

            var entity = new SjekklisteEntity
            {
                MekanikerNavn = sjekkliste.UpsertModel.MekanikerNavn,
                SerieNummer = sjekkliste.UpsertModel.SerieNummer,
                Dato = sjekkliste.UpsertModel.Dato,
                AntallTimer = sjekkliste.UpsertModel.AntallTimer,
                MekanikerKommentar = sjekkliste.UpsertModel.MekanikerKommentar,
                SjekklisteID = sjekkliste.UpsertModel.SjekklisteID,
                OrdreNummer = sjekkliste.UpsertModel.OrdreNummer,
                StatusString = radiobuttons.createStatusString(sjekkliste),
            };
            _sjekklisteRepository.Upsert(entity);
            return Redirect("Index");
        }

        /// <summary>
        /// Creates a SjekkListeFullViewMode for other methods to use.
        /// </summary>
        /// <returns>A SjekkListeFullViewMode containing an UpsertModel and a List of all instances in the ordre repository.</returns>
        private SjekklisteFullViewModel CreateSjekkListeFullViewModel()
        {
            return new SjekklisteFullViewModel
            {
                UpsertModel = new SjekklisteViewModel
                {
                    AntallTimer = 0,
                    Dato = DateOnly.FromDateTime(DateTime.Today),
                    JobGroups = new List<SjekklisteJobGroupModel> {
                        new SjekklisteJobGroupModel
                        { Name = "Mekanisk",
                            Jobs = new List<Jobs> { new Jobs { Name = "Sjekk clutch lameller for slitasje", Value = -1 }, new Jobs { Name = "Sjekk bremser. Bånd/Pal", Value = -1 }, new Jobs { Name = "Sjekk lager for trommel", Value = -1 }, new Jobs { Name = "Sjekk PTO og opplagring", Value = -1 }, new Jobs { Name = "Sjekk kjedestrammer", Value = -1 }, new Jobs { Name = "Sjekk wire", Value = -1 }, new Jobs { Name = "Sjekk pinion lager", Value = -1 }, new Jobs { Name = "Sjekk kile på kjedehjul", Value = -1 } }
                        },
                        new SjekklisteJobGroupModel
                        { Name = "Hydraulisk",
                            Jobs = new List<Jobs> { new Jobs { Name = "Sjekk hydraulisk sylinder for lekkasje", Value = -1 }, new Jobs { Name = "Sjekk slanger for skader og lekkasje", Value = -1 }, new Jobs { Name = "Test hydraulikkblokk i testbenk", Value = -1 }, new Jobs { Name = "Skift olje i tank", Value = -1 }, new Jobs { Name = "Skift olje på gir boks", Value = -1 }, new Jobs { Name = "Sjekk Ringsylinder åpne og skift tetninger", Value = -1 }, new Jobs { Name = "Sjekk bremse sylinder åpne og skift tetninger", Value = -1 } }
                        },
                        new SjekklisteJobGroupModel
                        { Name = "Elektro",
                            Jobs = new List<Jobs> { new Jobs { Name = "Sjekk ledningsnett på vinsj", Value = -1 }, new Jobs { Name = "Sjekk og test radio", Value = -1 }, new Jobs { Name = "Sjekk og test knappekasse", Value = -1 } }
                        },
                        new SjekklisteJobGroupModel
                        { Name = "Trykk settinger",
                            Jobs = new List<Jobs> { new Jobs { Name = "xx- bar", Value = -1 } }
                        },
                        new SjekklisteJobGroupModel
                        { Name = "Funksjons test",
                            Jobs = new List<Jobs> { new Jobs { Name = "Test vinsj og kjør alle funksjoner", Value = -1 }, new Jobs { Name = "Trekkraft KN", Value = -1 }, new Jobs { Name = "Bremse kraft KN", Value = -1 } }
                        },
                    },
                    MekanikerNavn = "",
                    MekanikerKommentar = "",
                    SerieNummer = "",
                    SjekklisteID = 1
                },
                SjekklisteOversikt = _sjekklisteRepository.GetAll().Select(x => new SjekklisteViewModel
                {
                    MekanikerNavn = x.MekanikerNavn,
                    SerieNummer = x.SerieNummer,
                    Dato = x.Dato,
                    AntallTimer = x.AntallTimer,
                    MekanikerKommentar = x.MekanikerKommentar,
                    SjekklisteID = x.SjekklisteID,
                    OrdreNummer = x.OrdreNummer,
                    StatusString = x.StatusString
                }).ToList()
            };
        }
    }
}
