using Igland.MVC.Controllers;
using Igland.MVC.Entities;
using Igland.MVC.Models.Home;
using Igland.MVC.Repositories.IRepo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Igland.MVC.Tests.Controllers
{

    public class HomeControllerUnitTests
    {
        private ILogger<HomeController> logger;
        private IArbDokRepository arbDokRepository;
        private IOrdreRepository ordreRepository;
        private IKunderRepository kunderRepository;

        private void InitializeFakes()
        {
            arbDokRepository = Substitute.For<IArbDokRepository>();
            arbDokRepository.GetAll().Returns(new List<ArbDok> { new ArbDok { ArbDokID = 10, OrdreNummer = 12345678, Kunde = "Kunde 1", Vinsj = "Vinsj 1", HenvendelseMotatt = new DateOnly(2023, 11, 24), AvtaltLevering = new DateOnly(2023, 11, 24), ProduktMotatt = new DateOnly(2023, 11, 24), SjekkUtfort = new DateOnly(2023, 11, 24), AvtaltFerdig = new DateOnly(2023, 11, 24), ServiceFerdig = new DateOnly(2023, 11, 24), AntallTimer = 5, BestillingFraKunde = "Bestilling fra kunde", NotatFraMekaniker = "Notat fra mekaniker", Status = "Status 1" }, });
            ordreRepository = Substitute.For<IOrdreRepository>();
            ordreRepository.GetAll().Returns(new List<OrdreEntity> { new OrdreEntity { OrdreNummer = 12345678, KundeID = 1, SerieNummer = "Serienummer1", VareNavn = "VareNavn", Status = "Status" }, });
            kunderRepository = Substitute.For<IKunderRepository>();
            kunderRepository.GetAll().Returns(new List<KunderEntity> { new KunderEntity { KundeID = 1, KundeNavn = "Pumba" } });
        }
        private HomeController GetUnitUnderTest()
        {
            InitializeFakes();
            var logger = Substitute.For<ILogger<HomeController>>();
            return new HomeController(logger, arbDokRepository, ordreRepository, kunderRepository);
        }

        [Fact]
        public async Task IndexReturnsCorrectModelType()
        {
            
            var unitUnderTest = GetUnitUnderTest();
            var result = unitUnderTest.Index() as ViewResult;
            Assert.IsType<HomeViewModel>(result.Model);
        }

        [Fact]
        public async Task IndexReturnsCorrectContent()
        {
            GetUnitUnderTest();
            var logger = Substitute.For<ILogger<HomeController>>();
            var controller = new HomeController(logger, arbDokRepository, ordreRepository, kunderRepository);
            var result = controller.Index() as ViewResult;
            var model = result.Model as HomeViewModel;

            Assert.NotNull(result);
            Assert.Equal("Index", result.ViewName);
            Assert.IsType<HomeViewModel>(result.Model);
            Assert.NotNull(model);
            Assert.NotNull(model.KunderOversikt);
        }

        [Fact]
        public void IndexFillsModelWithData()
        {
            var logger = Substitute.For<ILogger<HomeController>>();
            GetUnitUnderTest();
            var controller = new HomeController(logger, arbDokRepository, ordreRepository, kunderRepository);
            var result = controller.Index() as ViewResult;
            var model = result.Model as HomeViewModel;

            Assert.NotNull(model);
            Assert.NotNull(model);
            Assert.NotNull(model.ArbDokList);
            Assert.NotNull(model.OrdreOversikt);
            Assert.NotNull(model.KunderOversikt);
        }

        [Fact]
        public void PrivacyReturnsCorrectView()
        {
            var logger = Substitute.For<ILogger<HomeController>>();
            var controller = new HomeController(logger, arbDokRepository, ordreRepository, kunderRepository); 
            var result = controller.Privacy() as ViewResult;

            Assert.NotNull(result);
            Assert.Same("Privacy", result.ViewName);
        }

    }
}
