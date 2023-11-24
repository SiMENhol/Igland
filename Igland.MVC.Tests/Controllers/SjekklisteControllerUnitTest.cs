using Igland.MVC.Controllers;
using Igland.MVC.Entities;
using Igland.MVC.Models.ServiceDokument;
using Igland.MVC.Models.Sjekkliste;
using Igland.MVC.Repositories.IRepo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;
using NSubstitute;


namespace Igland.MVC.Tests.Controllers
{
    public class SjekklisteControllerUnitTest
    {
        private ISjekklisteRepository sjekklisteRepository;
        private ILogger<SjekklisteController> logger;
        private void InitializeFakes()
        {
            sjekklisteRepository = Substitute.For<ISjekklisteRepository>();
            sjekklisteRepository.GetAll().Returns(new List<SjekklisteEntity> { new SjekklisteEntity { MekanikerNavn = "Mekaniker navn", SerieNummer = "Serienummer", Dato = new DateOnly(2023, 11, 24), AntallTimer = new decimal(11), MekanikerKommentar = "Kommentar fra mekaniker", SjekklisteID = 12345, OrdreNummer = 12345678, StatusString = "2,1,3,2,1,2,1,1,1" } });
        }

        private SjekklisteController GetUnitUnderTest()
        {
            InitializeFakes();
            var logger = Substitute.For<ILogger<SjekklisteController>>();
            return new SjekklisteController(logger, sjekklisteRepository);
        }
        [Fact]
        public async Task IndexReturnsCorrectModelType()
        {
            var unitUnderTest = GetUnitUnderTest();
            var result = unitUnderTest.Index() as ViewResult;
            Assert.IsType<SjekklisteFullViewModel>(result.Model);
        }
        [Fact]
        public async Task NyReturnsCorrectModelType()
        {
            var unitUnderTest = GetUnitUnderTest();
            var result = unitUnderTest.Ny() as ViewResult;
            Assert.IsType<SjekklisteFullViewModel>(result.Model);
        }
        [Fact]
        public async Task RedigerReturnsCorrectModelType()
        {
            var unitUnderTest = GetUnitUnderTest();
            var result = unitUnderTest.Rediger() as ViewResult;
            Assert.IsType<SjekklisteFullViewModel>(result.Model);
        }

        [Fact]
        public async Task IndexReturnsCorrectContent()
        {
            var unitUnderTest = GetUnitUnderTest();
            var logger = Substitute.For<ILogger<SjekklisteController>>();
            var controller = new SjekklisteController(logger, sjekklisteRepository);

            var result = controller.Index() as ViewResult;

            Assert.NotNull(result);
            Assert.Equal("Index", result.ViewName);

            Assert.IsType<SjekklisteFullViewModel>(result.Model);
            var model = result.Model as SjekklisteFullViewModel;
            Assert.NotNull(model);
            Assert.NotNull(model.SjekklisteOversikt);
        }
        [Fact]
        public async Task NyReturnsCorrectContent()
        {
            var unitUnderTest = GetUnitUnderTest();
            var logger = Substitute.For<ILogger<SjekklisteController>>();
            var controller = new SjekklisteController(logger, sjekklisteRepository);

            var result = controller.Ny() as ViewResult;

            Assert.NotNull(result);
            Assert.Equal("Ny", result.ViewName);

            Assert.IsType<SjekklisteFullViewModel>(result.Model);
            var model = result.Model as SjekklisteFullViewModel;
            Assert.NotNull(model);
            Assert.NotNull(model.SjekklisteOversikt);
        }

        [Fact]
        public async Task RedigerReturnsCorrectContent()
        {
            var unitUnderTest = GetUnitUnderTest();
            var logger = Substitute.For<ILogger<SjekklisteController>>();
            var controller = new SjekklisteController(logger, sjekklisteRepository);

            var result = controller.Rediger() as ViewResult;

            Assert.NotNull(result);
            Assert.Equal("Rediger", result.ViewName);

            Assert.IsType<SjekklisteFullViewModel>(result.Model);
            var model = result.Model as SjekklisteFullViewModel;
            Assert.NotNull(model);
            Assert.NotNull(model.SjekklisteOversikt);
        }


        [Fact]
        public async Task IndexFillsModelWithData()
        {
            var logger = Substitute.For<ILogger<SjekklisteController>>();
            var unitUnderTest = GetUnitUnderTest();
            var controller = new SjekklisteController(logger, sjekklisteRepository);
            var result = controller.Index() as ViewResult;
            var model = result.Model as SjekklisteFullViewModel;
            Assert.NotNull(model);
            Assert.NotNull(model.SjekklisteOversikt);

        }
        [Fact]
        public async Task NyFillsModelWithData()
        {
            var logger = Substitute.For<ILogger<SjekklisteController>>();
            var unitUnderTest = GetUnitUnderTest();
            var controller = new SjekklisteController(logger, sjekklisteRepository);
            var result = controller.Ny() as ViewResult;
            var model = result.Model as SjekklisteFullViewModel;
            Assert.NotNull(model);
            Assert.NotNull(model.SjekklisteOversikt);

        }
        [Fact]
        public async Task RedigerFillsModelWithData()
        {
            var logger = Substitute.For<ILogger<SjekklisteController>>();
            var unitUnderTest = GetUnitUnderTest();
            var controller = new SjekklisteController(logger, sjekklisteRepository);
            var result = controller.Rediger() as ViewResult;
            var model = result.Model as SjekklisteFullViewModel;
            Assert.NotNull(model);
            Assert.NotNull(model.SjekklisteOversikt);

        }

        [Fact]
        public async Task PostSendsCorrectValuesToRepository()
        {
            var unitUnderTest = GetUnitUnderTest();
            unitUnderTest.Post(new SjekklisteFullViewModel
            {
                UpsertModel = new SjekklisteViewModel
                { 
                    MekanikerNavn = "Mekaniker navn",
                    SerieNummer = "Serienummer", 
                    Dato = new DateOnly(2023, 11, 24), 
                    AntallTimer = new decimal(11), 
                    MekanikerKommentar = "Kommentar fra mekaniker", 
                    SjekklisteID = 12345, 
                    OrdreNummer = 12345678,
                    StatusString = "2,1,3,2,1,2,1,1,1" }
            });
            sjekklisteRepository.Received().Upsert(Arg.Any<SjekklisteEntity>());
            sjekklisteRepository.Received().Upsert(Arg.Is<SjekklisteEntity>(sjekklisteEntity =>
            sjekklisteEntity.SjekklisteID == 12345));
            sjekklisteRepository.Received().Upsert(Arg.Is<SjekklisteEntity>(sjekklisteEntity =>
            sjekklisteEntity.SerieNummer == "Serienummer"
            ));
        }
        /* Vi har ikke delete knapp enda, men den kan/skal bli lagt til derav en eks på hvordan det kan gjøres
        [Fact]
        public void DeleteWithAdministratorRoleReturnsRedirectToActionResult()
        {
            var controller = GetUnitUnderTest();
            var serviceSkjemaID = 1;
            var result = controller.Delete(serviceSkjemaID) as RedirectToActionResult;
            Assert.NotNull(result);
            Assert.Equal("Index", result.ActionName);
        }
        [Fact]
        public void DeleteWithoutAdministratorRoleReturnsUnauthorized()
        {
            var controller = GetUnitUnderTest();
            var serviceSkjemaID = 1;
            var result = controller.Delete(serviceSkjemaID) as UnauthorizedResult;
            Assert.Null(result);
        } */ 
    }
}
