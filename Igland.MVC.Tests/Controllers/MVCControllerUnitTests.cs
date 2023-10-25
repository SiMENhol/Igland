using Igland.MVC.Controllers;
using Igland.MVC.Entities;
using Igland.MVC.Models.Home;
using Igland.MVC.Models.ServiceDocOversikt;
using Igland.MVC.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations;

namespace Igland.MVC.Tests.Controllers
{
#pragma warning disable CS8602 //Disable null reference warnings, if something is null the test should fail. 

    public class MVCControllerUnitTests
    {

        [Fact]
        public async Task IndexReturnsCorrectModelType()
        {
            var userRepository = Substitute.For<IUserRepository>();
            var logger = Substitute.For<ILogger<HomeController>>(); // Mock the logger

            userRepository.GetAll().Returns(new List<UserEntity> { new UserEntity { Id = 1, Name = "Igland Admin", Email = "Igland@example.com" } });

            var unitUnderTest = new HomeController(logger, userRepository);

            var result = unitUnderTest.Index() as ViewResult;

            Assert.IsType<HomeFullViewModel>(result.Model);
        }
        
        [Fact]
        public void IndexReturnsCorrectContent()
        {
            var unitUnderTest = SetupUnitUnderTest();
            var result = unitUnderTest.Index() as ViewResult;
            Assert.Same("Index", result.ViewName);
        }
        
                [Fact]
                public void UsingRazorReturnsCorrectModel()
                {
                    var unitUnderTest = SetupUnitUnderTest();
                    var result = unitUnderTest.Index() as ViewResult;
                    Assert.IsType<HomeFullViewModel>(result.Model);
                }

                [Fact]
                public void UsingRazorReturnsCorrectModelContent()
                {
                    var unitUnderTest = SetupUnitUnderTest();
                    var result = unitUnderTest.Index() as ViewResult;
                    var model = result.Model as HomeFullViewModel;
                    Assert.NotNull(model.UserList); // Check that UserList is not null
                }

        private HomeController SetupUnitUnderTest()
        {
            var logger = Substitute.For<ILogger<HomeController>>();
            var userRepository = Substitute.For<IUserRepository>();
            userRepository.GetAll().Returns(new List<UserEntity> { new UserEntity { Id = 1, Name = "Igland Admin", Email = "Igland@example.com" } });

            return new HomeController(logger, userRepository);
        }

    }
    public class FakeLogger<T> : ILogger<T>
    {

        public IDisposable? BeginScope<TState>(TState state) where TState : notnull
        {
            throw new NotImplementedException();
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
        {

        }
    }
}