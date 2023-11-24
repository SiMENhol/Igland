using Igland.MVC.Controllers;
using Igland.MVC.Entities;
using Igland.MVC.Models.Home;
using Igland.MVC.Models.Kunder;
using Igland.MVC.Repositories.IRepo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NSubstitute;

namespace Igland.MVC.Tests.Controllers
{
    public class KunderControllerUnitTests
    {
        private IKunderRepository kunderRepository;
        private ILogger<KunderController> logger;
        private void InitializeFakes()
        {
            kunderRepository = Substitute.For<IKunderRepository>();
            kunderRepository.GetAll().Returns(new List<KunderEntity> { new KunderEntity { KundeID = 1, KundeNavn = "Pumba" } });
        }

        private KunderController GetUnitUnderTest()
        {
            InitializeFakes();
            return new KunderController(logger, kunderRepository);
        }
        [Fact]
        public async Task IndexReturnsCorrectModelType()
        {
            var unitUnderTest = GetUnitUnderTest();
            var result = unitUnderTest.Index() as ViewResult;
            Assert.IsType<KunderFullViewModel>(result.Model);
        }

        [Fact]
        public async Task IndexReturnsCorrectContent()
        {
            var unitUnderTest = GetUnitUnderTest();

            var controller = new KunderController(logger, kunderRepository);

            var result = controller.Index() as ViewResult;

            Assert.NotNull(result);
            Assert.Equal("Index", result.ViewName);

            Assert.IsType<KunderFullViewModel>(result.Model);
            var model = result.Model as KunderFullViewModel;
            Assert.NotNull(model);
            Assert.NotNull(model.KunderOversikt);
        }

        [Fact]
        public async Task IndexFillsModelWithData()
        {

            var unitUnderTest = GetUnitUnderTest();
            var controller = new KunderController(logger, kunderRepository);
            var result = controller.Index() as ViewResult;
            var model = result.Model as KunderFullViewModel;
            Assert.NotNull(model);
            Assert.NotNull(model.KunderOversikt);

        }
        [Fact]
        public async Task NyReturnsCorrectModelType()
        {
            var unitUnderTest = GetUnitUnderTest();
            var result = unitUnderTest.Ny() as ViewResult;
            Assert.IsType<KunderFullViewModel>(result.Model);
        }

        [Fact]
        public async Task NyReturnsCorrectContent()
        {
            var unitUnderTest = GetUnitUnderTest();

            var controller = new KunderController(logger, kunderRepository);

            var result = controller.Ny() as ViewResult;

            Assert.NotNull(result);
            Assert.Equal("Ny", result.ViewName);

            Assert.IsType<KunderFullViewModel>(result.Model);
            var model = result.Model as KunderFullViewModel;
            Assert.NotNull(model);
            Assert.NotNull(model.KunderOversikt);
        }

        [Fact]
        public async Task NyFillsModelWithData()
        {

            var unitUnderTest = GetUnitUnderTest();
            var controller = new KunderController(logger, kunderRepository);
            var result = controller.Ny() as ViewResult;
            var model = result.Model as KunderFullViewModel;
            Assert.NotNull(model);
            Assert.NotNull(model.KunderOversikt);

        }
        [Fact]
        public async Task RedigerReturnsCorrectModelType()
        {
            var unitUnderTest = GetUnitUnderTest();
            var result = unitUnderTest.Rediger() as ViewResult;
            Assert.IsType<KunderFullViewModel>(result.Model);
        }

        [Fact]
        public async Task RedigerReturnsCorrectContent()
        {
            var unitUnderTest = GetUnitUnderTest();

            var controller = new KunderController(logger, kunderRepository);

            var result = controller.Rediger() as ViewResult;

            Assert.NotNull(result);
            Assert.Equal("Rediger", result.ViewName);

            Assert.IsType<KunderFullViewModel>(result.Model);
            var model = result.Model as KunderFullViewModel;
            Assert.NotNull(model);
            Assert.NotNull(model.KunderOversikt);
        }

        [Fact]
        public async Task RedigerFillsModelWithData()
        {

            var unitUnderTest = GetUnitUnderTest();
            var controller = new KunderController(logger, kunderRepository);
            var result = controller.Rediger() as ViewResult;
            var model = result.Model as KunderFullViewModel;
            Assert.NotNull(model);
            Assert.NotNull(model.KunderOversikt);

        }

        [Fact]
        public async Task PostSendsCorrectValuesToRepository()
        {
            var unitUnderTest = GetUnitUnderTest();
            unitUnderTest.Post(new KunderFullViewModel
            {
                UpsertModel = new KunderViewModel
                {
                    KundeID = 5,
                    KundeNavn = "Kunde 5"
                }
            });
            var sp = kunderRepository.ReceivedCalls().First().GetArguments().First() as KunderEntity;
            Assert.Equal(5, sp.KundeID);
        }
    }
}