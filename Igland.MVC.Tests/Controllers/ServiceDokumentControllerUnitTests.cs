using Igland.MVC.Controllers;
using Igland.MVC.Entities;
using Igland.MVC.Models.ServiceDokument;
using Igland.MVC.Repositories.IRepo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;
using NSubstitute;


namespace Igland.MVC.Tests.Controllers
{
    public class ServiceDokumentControllerUnitTests
    {
        private IServiceDokumentRepository servicedocRepository;
        private ILogger<ServiceDokumentController> logger;
        private void InitializeFakes()
        {
            servicedocRepository = Substitute.For<IServiceDokumentRepository>();
            servicedocRepository.GetAll().Returns(new List<ServiceDokumentEntity> { new ServiceDokumentEntity { ServiceSkjemaID = 1, OrdreNummer = 12345678, Aarsmodel = 2013, Garanti = "6 mnd", Reparasjonsbeskrivelse = "Reperasjonsbeskrivelse", MedgaatteDeler = "Medgatte deler", DeleRetur = "Deler for retur", ForesendelsesMaate = "Via posten" } });
        }

        private ServiceDokumentController GetUnitUnderTest()
        {
            InitializeFakes();
            var logger = Substitute.For<ILogger<ServiceDokumentController>>();
            return new ServiceDokumentController(logger, servicedocRepository);
        }
        [Fact]
        public async Task IndexReturnsCorrectModelType()
        {
            var unitUnderTest = GetUnitUnderTest();
            var result = unitUnderTest.Index() as ViewResult;
            Assert.IsType<ServiceDokumentFullViewModel>(result.Model);
        }

        [Fact]
        public async Task IndexReturnsCorrectContent()
        {
            var unitUnderTest = GetUnitUnderTest();
            var logger = Substitute.For<ILogger<ServiceDokumentController>>();
            var controller = new ServiceDokumentController(logger, servicedocRepository);

            var result = controller.Index() as ViewResult;

            Assert.NotNull(result);
            Assert.Equal("Index", result.ViewName);

            Assert.IsType<ServiceDokumentFullViewModel>(result.Model);
            var model = result.Model as ServiceDokumentFullViewModel;
            Assert.NotNull(model);
            Assert.NotNull(model.ServiceDokumentOversikt);
        }

        [Fact]
        public async Task IndexFillsModelWithData()
        {
            var logger = Substitute.For<ILogger<ServiceDokumentController>>();
            var unitUnderTest = GetUnitUnderTest();
            var controller = new ServiceDokumentController(logger, servicedocRepository);
            var result = controller.Index() as ViewResult;
            var model = result.Model as ServiceDokumentFullViewModel;
            Assert.NotNull(model);
            Assert.NotNull(model.ServiceDokumentOversikt);

        }
        [Fact]
        public async Task RedigerReturnsCorrectModelType()
        {
            var unitUnderTest = GetUnitUnderTest();
            var result = unitUnderTest.Rediger() as ViewResult;
            Assert.IsType<ServiceDokumentFullViewModel>(result.Model);
        }

        [Fact]
        public async Task RedigerReturnsCorrectContent()
        {
            var unitUnderTest = GetUnitUnderTest();
            var logger = Substitute.For<ILogger<ServiceDokumentController>>();
            var controller = new ServiceDokumentController(logger, servicedocRepository);

            var result = controller.Rediger() as ViewResult;

            Assert.NotNull(result);
            Assert.Equal("Rediger", result.ViewName);

            Assert.IsType<ServiceDokumentFullViewModel>(result.Model);
            var model = result.Model as ServiceDokumentFullViewModel;
            Assert.NotNull(model);
            Assert.NotNull(model.ServiceDokumentOversikt);
        }

        [Fact]
        public async Task RedigerFillsModelWithData()
        {
            var logger = Substitute.For<ILogger<ServiceDokumentController>>();
            var unitUnderTest = GetUnitUnderTest();
            var controller = new ServiceDokumentController(logger, servicedocRepository);
            var result = controller.Rediger() as ViewResult;
            var model = result.Model as ServiceDokumentFullViewModel;
            Assert.NotNull(model);
            Assert.NotNull(model.ServiceDokumentOversikt);

        }
        [Fact]
        public async Task NyReturnsCorrectModelType()
        {
            var unitUnderTest = GetUnitUnderTest();
            var result = unitUnderTest.Ny() as ViewResult;
            Assert.IsType<ServiceDokumentFullViewModel>(result.Model);
        }

        [Fact]
        public async Task NyReturnsCorrectContent()
        {
            var unitUnderTest = GetUnitUnderTest();
            var logger = Substitute.For<ILogger<ServiceDokumentController>>();
            var controller = new ServiceDokumentController(logger, servicedocRepository);

            var result = controller.Ny() as ViewResult;

            Assert.NotNull(result);
            Assert.Equal("Ny", result.ViewName);

            Assert.IsType<ServiceDokumentFullViewModel>(result.Model);
            var model = result.Model as ServiceDokumentFullViewModel;
            Assert.NotNull(model);
            Assert.NotNull(model.ServiceDokumentOversikt);
        }

        [Fact]
        public async Task NyFillsModelWithData()
        {
            var logger = Substitute.For<ILogger<ServiceDokumentController>>();
            var unitUnderTest = GetUnitUnderTest();
            var controller = new ServiceDokumentController(logger, servicedocRepository);
            var result = controller.Ny() as ViewResult;
            var model = result.Model as ServiceDokumentFullViewModel;
            Assert.NotNull(model);
            Assert.NotNull(model.ServiceDokumentOversikt);

        }

        [Fact]
        public async Task PostSendsCorrectValuesToRepository()
        {
            var unitUnderTest = GetUnitUnderTest();
            unitUnderTest.Post(new ServiceDokumentFullViewModel
            {
                UpsertModel = new ServiceDokumentViewModel
                {
                    ServiceSkjemaID = 1,
                    OrdreNummer = 87654321,
                    Aarsmodel = 2014,
                    Garanti = "12 mnd",
                    Reparasjonsbeskrivelse = "Reperasjonsbeskrivelse",
                    MedgaatteDeler = "Trommel deler",
                    DeleRetur = "Bremser",
                    ForesendelsesMaate = "Via posten"
                }
            });
            servicedocRepository.Received().Upsert(Arg.Any<ServiceDokumentEntity>());
            servicedocRepository.Received().Upsert(Arg.Is<ServiceDokumentEntity>(serviceDokumentEntity =>
            serviceDokumentEntity.ServiceSkjemaID == 1));
            servicedocRepository.Received().Upsert(Arg.Is<ServiceDokumentEntity>(serviceDokumentEntity =>
            serviceDokumentEntity.DeleRetur == "Bremser"
            ));
        }

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
        }
    }
}
