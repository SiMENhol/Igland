using Igland.MVC.Controllers;
using Igland.MVC.Entities;
using Igland.MVC.Models.ArbDok;
using Igland.MVC.Repositories.IRepo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;


namespace Igland.MVC.Tests.Controllers
{

    public class ArbDokControllerUnitTest
    {
        private ILogger<ArbDokController> logger;
        private IArbDokRepository arbDokRepository;
        private IOrdreRepository ordreRepository;
        private IKunderRepository kunderRepository;
        private void InitializeFakes()
        {
            arbDokRepository = Substitute.For<IArbDokRepository>();
            arbDokRepository.GetAll().Returns(new List<ArbDok> { new ArbDok { ArbDokID = 10, OrdreNummer = 12345678, Uke = "50", HenvendelseMotatt = new DateOnly(2023, 11, 24), AvtaltLevering = new DateOnly(2023, 11, 24), ProduktMotatt = new DateOnly(2023, 11, 24), SjekkUtfort = new DateOnly(2023, 11, 24), AvtaltFerdig = new DateOnly(2023, 11, 24), ServiceFerdig = new DateOnly(2023, 11, 24), AntallTimer = 5, BestillingFraKunde = "Bestilling fra kunde", NotatFraMekaniker = "Notat fra mekaniker" }, });

            kunderRepository = Substitute.For<IKunderRepository>();
            kunderRepository.GetAll().Returns(new List<KunderEntity> { new KunderEntity { KundeID = 1, KundeNavn = "Pumba" } });

            ordreRepository = Substitute.For<IOrdreRepository>();
            ordreRepository.GetAll().Returns(new List<OrdreEntity> { new OrdreEntity { OrdreNummer = 12345678, KundeID = 1, SerieNummer = "Serienummer1", VareNavn = "VareNavn", Status = "Status" }, });


        }

        private ArbDokController GetUnitUnderTest()
        {
            InitializeFakes();
            var logger = Substitute.For<ILogger<ArbDokController>>();
            return new ArbDokController(logger, arbDokRepository, ordreRepository, kunderRepository);
        }
        [Fact]
        public async Task IndexReturnsCorrectModelType()
        {
            var unitUnderTest = GetUnitUnderTest();
            var result = unitUnderTest.Index() as ViewResult;
            Assert.IsType<ArbDokFullViewModel>(result.Model);
        }
        [Fact]
        public async Task NyReturnsCorrectModelType()
        {
            var unitUnderTest = GetUnitUnderTest();
            var result = unitUnderTest.Ny() as ViewResult;
            Assert.IsType<ArbDokFullViewModel>(result.Model);
        }
        [Fact]
        public async Task RedigerReturnsCorrectModelType()
        {
            var unitUnderTest = GetUnitUnderTest();
            var result = unitUnderTest.Rediger() as ViewResult;
            Assert.IsType<ArbDokFullViewModel>(result.Model);
        }

        [Fact]
        public async Task IndexReturnsCorrectContent()
        {
            var unitUnderTest = GetUnitUnderTest();
            var logger = Substitute.For<ILogger<ArbDokController>>();
            var controller = new ArbDokController(logger, arbDokRepository, ordreRepository, kunderRepository);

            var result = controller.Index() as ViewResult;

            Assert.NotNull(result);
            Assert.Equal("Index", result.ViewName);

            Assert.IsType<ArbDokFullViewModel>(result.Model);
            var model = result.Model as ArbDokFullViewModel;
            Assert.NotNull(model);
            Assert.NotNull(model.ArbDokList);
        }

        [Fact]
        public async Task IndexFillsModelWithData()
        {
            var logger = Substitute.For<ILogger<ArbDokController>>();
            var unitUnderTest = GetUnitUnderTest();
            var controller = new ArbDokController(logger, arbDokRepository, ordreRepository, kunderRepository);
            var result = controller.Index() as ViewResult;
            var model = result.Model as ArbDokFullViewModel;
            Assert.NotNull(model);
            Assert.NotNull(model.ArbDokList);

        }

        [Fact]
        public async Task NyReturnsCorrectContent()
        {
            var unitUnderTest = GetUnitUnderTest();
            var logger = Substitute.For<ILogger<ArbDokController>>();
            var controller = new ArbDokController(logger, arbDokRepository, ordreRepository, kunderRepository);

            var result = controller.Ny() as ViewResult;

            Assert.NotNull(result);
            Assert.Equal("Ny", result.ViewName);

            Assert.IsType<ArbDokFullViewModel>(result.Model);
            var model = result.Model as ArbDokFullViewModel;
            Assert.NotNull(model);
            Assert.NotNull(model.ArbDokList);
        }

        [Fact]
        public async Task NyFillsModelWithData()
        {
            var logger = Substitute.For<ILogger<ArbDokController>>();
            var unitUnderTest = GetUnitUnderTest();
            var controller = new ArbDokController(logger, arbDokRepository, ordreRepository, kunderRepository);
            var result = controller.Ny() as ViewResult;
            var model = result.Model as ArbDokFullViewModel;
            Assert.NotNull(model);
            Assert.NotNull(model.ArbDokList);

        }
        [Fact]
        public async Task RedigerReturnsCorrectContent()
        {
            var unitUnderTest = GetUnitUnderTest();
            var logger = Substitute.For<ILogger<ArbDokController>>();
            var controller = new ArbDokController(logger, arbDokRepository, ordreRepository, kunderRepository);

            var result = controller.Rediger() as ViewResult;

            Assert.NotNull(result);
            Assert.Equal("Rediger", result.ViewName);

            Assert.IsType<ArbDokFullViewModel>(result.Model);
            var model = result.Model as ArbDokFullViewModel;
            Assert.NotNull(model);
            Assert.NotNull(model.ArbDokList);
        }

        [Fact]
        public async Task RedigerModelWithData()
        {
            var logger = Substitute.For<ILogger<ArbDokController>>();
            var unitUnderTest = GetUnitUnderTest();
            var controller = new ArbDokController(logger, arbDokRepository, ordreRepository, kunderRepository);
            var result = controller.Rediger() as ViewResult;
            var model = result.Model as ArbDokFullViewModel;
            Assert.NotNull(model);
            Assert.NotNull(model.ArbDokList);

        }

        [Fact]
        public async Task PostSendsCorrectValuesToRepository()
        {
            var unitUnderTest = GetUnitUnderTest();
            unitUnderTest.Post(new ArbDokFullViewModel
            {
                UpsertArbDok = new ArbDokViewModel
                {
                    ArbDokID = 40,
                    OrdreNummer = 87654321,
                    Uke = "49",
                    HenvendelseMotatt = new DateOnly(2023, 12, 24),
                    AvtaltLevering = new DateOnly(2023, 12, 24),
                    ProduktMotatt = new DateOnly(2023, 12, 24),
                    SjekkUtfort = new DateOnly(2023, 12, 24),
                    AvtaltFerdig = new DateOnly(2023, 12, 24),
                    ServiceFerdig = new DateOnly(2023, 12, 24),
                    AntallTimer = 5, BestillingFraKunde = "Kunde bestilling",
                    NotatFraMekaniker = "Mekaniker notat",
                } 
            });
            arbDokRepository.Received().Upsert(Arg.Any<ArbDok>());
            arbDokRepository.Received().Upsert(Arg.Is<ArbDok>(arbDok =>
            arbDok.OrdreNummer == 87654321
            ));
            arbDokRepository.Received().Upsert(Arg.Is<ArbDok>(arbDok =>
            arbDok.NotatFraMekaniker == "Mekaniker notat"
            ));

        }
        
        [Fact]
        public void DeleteWithAdministratorRoleReturnsRedirectToActionResult()
        {
            var controller = GetUnitUnderTest();
            var ArbDokID = 1;
            var result = controller.Delete(ArbDokID) as RedirectToActionResult;
            Assert.NotNull(result);
            Assert.Equal("Index", result.ActionName);
        }
        [Fact]
        public void DeleteWithoutAdministratorRoleReturnsUnauthorized()
        {
            var controller = GetUnitUnderTest();
            var ArbDokID = 1;
            var result = controller.Delete(ArbDokID) as UnauthorizedResult;
            Assert.Null(result);
        } 
    }
}
