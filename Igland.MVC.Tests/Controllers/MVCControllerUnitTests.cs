using Igland.MVC.Controllers;
using Igland.MVC.Models;
using Igland.MVC.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Igland.MVC.Tests.Controllers
{
#pragma warning disable CS8602 //Disable null reference warnings, if something is null the test should fail. 

    public class MVCControllerUnitTests
    {
        private static IUserRepository userRepository;

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
            Assert.IsType<RazorViewModel>(result.Model);
        }

        [Fact]
        public void UsingRazorReturnsCorrectModelContent()  
        {
            var unitUnderTest = SetupUnitUnderTest();
            var result = unitUnderTest.Index() as ViewResult;
            var model = result.Model as RazorViewModel;
            Assert.Same("Hva vil du gjøre idag?", model.Content);
        }

        
        private static HomeController SetupUnitUnderTest()
        {
            var fakeLogger = new FakeLogger<HomeController>(); //Set up a fake for dependency (this works with all interfaces)
            var unitUnderTest = new HomeController(fakeLogger, userRepository); //Create the class we want to test
            return unitUnderTest;
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
