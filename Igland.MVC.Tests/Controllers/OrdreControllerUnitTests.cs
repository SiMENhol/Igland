using Castle.Core.Logging;
using Igland.MVC.Controllers;
using Igland.MVC.Entities;
using Igland.MVC.Models.ArbDok;
using Igland.MVC.Models.Home;
using Igland.MVC.Models.Kunder;
using Igland.MVC.Models.Ordre;
using Igland.MVC.Models.ServiceDokument;
using Igland.MVC.Models.Sjekkliste;
using Igland.MVC.Repositories.EF;
using Igland.MVC.Repositories.IRepo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using static Dapper.SqlMapper;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Igland.MVC.Tests.Controllers
{

    public class OrdreControllerUnitTests
    {
        private ILogger<OrdreController> logger;
        private IArbDokRepository arbDokRepository;
        private IOrdreRepository ordreRepository;
        private IKunderRepository kunderRepository;
        private ISjekklisteRepository sjekklisteRepository;
        private IServiceDokumentRepository servicedocRepository;


        private void InitializeFakes()
        {
            arbDokRepository = Substitute.For<IArbDokRepository>();
            arbDokRepository.GetAll().Returns(new List<ArbDok> { new ArbDok { ArbDokID = 10, Uke = "50", OrdreNummer = 12345678, HenvendelseMotatt = new DateOnly(2023, 11, 24), AvtaltLevering = new DateOnly(2023, 11, 24), ProduktMotatt = new DateOnly(2023, 11, 24), SjekkUtfort = new DateOnly(2023, 11, 24), AvtaltFerdig = new DateOnly(2023, 11, 24), ServiceFerdig = new DateOnly(2023, 11, 24), AntallTimer = 5, BestillingFraKunde = "Bestilling fra kunde", NotatFraMekaniker = "Notat fra mekaniker" }, });


            ordreRepository = Substitute.For<IOrdreRepository>();
            ordreRepository.GetAll().Returns(new List<OrdreEntity> { new OrdreEntity { OrdreNummer = 12345678, KundeID = 1, SerieNummer = "Serienummer1", VareNavn = "VareNavn", Status = "Status" }, });


            kunderRepository = Substitute.For<IKunderRepository>();
            kunderRepository.GetAll().Returns(new List<KunderEntity> { new KunderEntity { KundeID = 1, KundeNavn = "Pumba" } });

            sjekklisteRepository = Substitute.For<ISjekklisteRepository>();
            sjekklisteRepository.GetAll().Returns(new List<SjekklisteEntity> { new SjekklisteEntity { MekanikerNavn = "Mekaniker navn", SerieNummer = "Serienummer", Dato = new DateOnly(2023,11,24), AntallTimer = new decimal(11), MekanikerKommentar = "Kommentar fra mekaniker", SjekklisteID = 12345, OrdreNummer = 12345678, StatusString = "2,1,3,2,1,2,1,1,1" } });

            servicedocRepository = Substitute.For<IServiceDokumentRepository>();
            servicedocRepository.GetAll().Returns(new List<ServiceDokumentEntity> { new ServiceDokumentEntity { ServiceSkjemaID = 1, OrdreNummer = 12345678, Aarsmodel= 2013, Garanti = "6 mnd", Reparasjonsbeskrivelse = "Reperasjonsbeskrivelse", MedgaatteDeler = "Medgatte deler", DeleRetur = "Deler for retur", ForesendelsesMaate = "Via posten" } });
        }
        private OrdreController GetUnitUnderTest()
        {
            InitializeFakes();
            var logger = Substitute.For<ILogger<OrdreController>>();
            return new OrdreController(logger, ordreRepository, arbDokRepository, sjekklisteRepository, servicedocRepository);
        }

        [Fact]
        public async Task IndexReturnsCorrectModelType()
        {
            var unitUnderTest = GetUnitUnderTest();
            var result = unitUnderTest.Index() as ViewResult;
            Assert.IsType<OrdreFullViewModel>(result.Model);
        }

        [Fact]
        public async Task IndexReturnsCorrectContent()
        {
            var unitUnderTest = GetUnitUnderTest();
            var logger = Substitute.For<ILogger<OrdreController>>();
            var controller = new OrdreController(logger, ordreRepository, arbDokRepository, sjekklisteRepository, servicedocRepository);

            var result = controller.Index() as ViewResult;

            Assert.NotNull(result);
            Assert.Equal("Index", result.ViewName);

            Assert.IsType<OrdreFullViewModel>(result.Model);
            var model = result.Model as OrdreFullViewModel;
            Assert.NotNull(model);

        }

        [Fact]
        public async Task IndexFillsModelWithData()
        {

            var logger = Substitute.For<ILogger<OrdreController>>();
            GetUnitUnderTest();
            var controller = new OrdreController(logger, ordreRepository, arbDokRepository, sjekklisteRepository, servicedocRepository); var result = controller.Index() as ViewResult;
            var model = result.Model as OrdreFullViewModel;

            Assert.NotNull(model);
            Assert.NotNull(model);
            Assert.NotNull(model.ArbDokList);
            Assert.NotNull(model.OrdreOversikt);
            Assert.NotNull(model.SjekkelistList);
            Assert.NotNull(model.ServiceDokumentOversikt);
        }
        [Fact]
        public async Task NyReturnsCorrectModelType()
        {
            var unitUnderTest = GetUnitUnderTest();
            var result = unitUnderTest.Ny() as ViewResult;
            Assert.IsType<OrdreFullViewModel>(result.Model);
        }

        [Fact]
        public async Task NyReturnsCorrectContent()
        {
            var unitUnderTest = GetUnitUnderTest();
            var logger = Substitute.For<ILogger<OrdreController>>();
            var controller = new OrdreController(logger, ordreRepository, arbDokRepository, sjekklisteRepository, servicedocRepository);

            var result = controller.Ny() as ViewResult;

            Assert.NotNull(result);
            Assert.Equal("Ny", result.ViewName);

            Assert.IsType<OrdreFullViewModel>(result.Model);
            var model = result.Model as OrdreFullViewModel;
            Assert.NotNull(model);

        }

        [Fact]
        public async Task NyFillsModelWithData()
        {

            var logger = Substitute.For<ILogger<OrdreController>>();
            GetUnitUnderTest();
            var controller = new OrdreController(logger, ordreRepository, arbDokRepository, sjekklisteRepository, servicedocRepository); 
            var result = controller.Ny() as ViewResult;
            var model = result.Model as OrdreFullViewModel;

            Assert.NotNull(model);
            Assert.NotNull(model);
            Assert.NotNull(model.ArbDokList);
            Assert.NotNull(model.OrdreOversikt);
            Assert.NotNull(model.SjekkelistList);
            Assert.NotNull(model.ServiceDokumentOversikt);
        }
        [Fact]
        public async Task RedigerReturnsCorrectModelType()
        {
            var unitUnderTest = GetUnitUnderTest();
            var result = unitUnderTest.Rediger() as ViewResult;
            Assert.IsType<OrdreFullViewModel>(result.Model);
        }

        [Fact]
        public async Task RedigerReturnsCorrectContent()
        {
            var unitUnderTest = GetUnitUnderTest();
            var logger = Substitute.For<ILogger<OrdreController>>();
            var controller = new OrdreController(logger, ordreRepository, arbDokRepository, sjekklisteRepository, servicedocRepository);

            var result = controller.Rediger() as ViewResult;

            Assert.NotNull(result);
            Assert.Equal("Rediger", result.ViewName);

            Assert.IsType<OrdreFullViewModel>(result.Model);
            var model = result.Model as OrdreFullViewModel;
            Assert.NotNull(model);

        }

        [Fact]
        public async Task RedigerFillsModelWithData()
        {

            var logger = Substitute.For<ILogger<OrdreController>>();
            GetUnitUnderTest();
            var controller = new OrdreController(logger, ordreRepository, arbDokRepository, sjekklisteRepository, servicedocRepository); 
            var result = controller.Rediger() as ViewResult;
            var model = result.Model as OrdreFullViewModel;

            Assert.NotNull(model);
            Assert.NotNull(model);
            Assert.NotNull(model.ArbDokList);
            Assert.NotNull(model.OrdreOversikt);
            Assert.NotNull(model.SjekkelistList);
            Assert.NotNull(model.ServiceDokumentOversikt);
        }
        [Fact]
        public async Task PostenSendsCorrectValuesToRepository()
        {
            var unitUnderTest = GetUnitUnderTest();

            unitUnderTest.Posten(new OrdreFullViewModel
            {
                UpsertModel = new OrdreViewModel
                {
                    OrdreNummer = 12345678,
                    KundeID = 2,
                    SerieNummer = "Serienummer post",
                    VareNavn = "Varnavn post",
                    Status = "Case ferdig"
                }
            });
            ordreRepository.Received().Upsert(Arg.Any<OrdreEntity>());
            ordreRepository.Received().Upsert(Arg.Is<OrdreEntity>(ordreEntity =>
            ordreEntity.KundeID == 2));
            ordreRepository.Received().Upsert(Arg.Is<OrdreEntity>(ordreEntity =>
            ordreEntity.SerieNummer == "Serienummer post"
            ));
        }
    }
}


        /*   public async Task PostSendsCorrectValuesToRepository()
       {
           var unitUnderTest = GetUnitUnderTest();

           unitUnderTest.Post(new OrdreFullViewModel
           {
               UpsertModel = new OrdreViewModel
               {
                   OrdreNummer = 12345678,
                   KundeID = 2,
                   SerieNummer = "Serienummer post",
                   VareNavn = "Varnavn post",
                   Status = "Case ferdig"
               },
               UpsertArbDok = new ArbDokFullViewModel
               {
                   ArbDokID = 19,
                   OrdreNummer = 87654321,
                   Kunde = "Kunde 2",
                   Vinsj = "Vinsj 3",
                   HenvendelseMotatt = new DateOnly(2023, 12, 24),
                   AvtaltLevering = new DateOnly(2023, 12, 24),
                   ProduktMotatt = new DateOnly(2023, 12, 24),
                   SjekkUtfort = new DateOnly(2023, 12, 24),
                   AvtaltFerdig = new DateOnly(2023, 12, 24),
                   ServiceFerdig = new DateOnly(2023, 12, 24),
                   AntallTimer = 10,
                   BestillingFraKunde = "Nei",
                   NotatFraMekaniker = "Notater",
                   Status = "Case ferdig"
               },
               UpsertSjekkliste = new SjekklisteFullViewModel
               {
                   MekanikerNavn = "Truls",
                   SerieNummer = "Nummersier",
                   Dato = new DateOnly(2023, 12, 24),
                   AntallTimer = new decimal(24),
                   MekanikerKommentar = "Kommentar",
                   SjekklisteID = 3215,
                   OrdreNummer = 87654321,
                   StatusString = "2,1,1,1,1,1,2,2,2"
               },
               UpsertServicedokument = new ServiceDokumentFullViewModel
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

           var ordreSp = ordreRepository.ReceivedCalls().First().GetArguments().First() as OrdreEntity;
       Assert.Equal(5, ordreSp.KundeID);

   var arbDokSp = arbDokRepository.ReceivedCalls().First().GetArguments().First() as ArbDok;
       Assert.Equal(5, arbDokSp.ArbDokID);

            var sjekklisteSp = sjekklisteRepository.ReceivedCalls().First().GetArguments().First() as SjekklisteEntity;
           Assert.Equal(5, sjekklisteSp.SjekklisteID);
           var servicedocSp = servicedocRepository.ReceivedCalls().First().GetArguments().First() as ServiceDokumentEntity;
       Assert.Equal(5, servicedocSp.OrdreNummer);
       }*/

