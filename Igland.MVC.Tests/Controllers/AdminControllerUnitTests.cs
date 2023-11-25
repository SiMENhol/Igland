using Castle.Core.Logging;
using Igland.MVC.Controllers;
using Igland.MVC.Entities;
using Igland.MVC.Models.Account;
using Igland.MVC.Models.ArbDok;
using Igland.MVC.Models.Users;
using Igland.MVC.Repositories.EF;
using Igland.MVC.Repositories.IRepo;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;

namespace Igland.MVC.Tests.Controllers
{

    public class AdminControllerUnitTests
    {
        private UserManager<IdentityUser> userManager;
        private ILogger<AdminController> logger;
        private IUserRepository userRepository;
        private void InitializeFakes()
        {
            var logger = Substitute.For<ILogger<AdminController>>();


            userRepository = Substitute.For<IUserRepository>();
            userRepository.GetUsers().Returns(new List<UserEntity>
        {
        new UserEntity
        {
            Id = "1",
            UserName = "Test@mail.com",
            Email = "Test@mail.com",
            PasswordHash = "AQAAAAIAAYagAAAAEJ4HQojIkMee85/uU6/LD85or3Sjq4EY/i8WTx1XuKKh9Ar6Ylb3EChdkFArT0A7lQ==",
        }
    });
        }

        private AdminController GetUnitUnderTest()
        {
            InitializeFakes();
            var logger = Substitute.For<ILogger<AdminController>>();

            var userStore = Mock.Of<IUserStore<IdentityUser>>();
            var identityOptions = Mock.Of<IOptions<IdentityOptions>>();
            var passwordHasher = Mock.Of<IPasswordHasher<IdentityUser>>();
            var userValidators = new List<IUserValidator<IdentityUser>>();
            var passwordValidators = new List<IPasswordValidator<IdentityUser>>();
            var keyNormalizer = Mock.Of<ILookupNormalizer>();
            var errors = Mock.Of<IdentityErrorDescriber>();
            var services = Mock.Of<IServiceProvider>();
            var loggerUserManager = Mock.Of<ILogger<UserManager<IdentityUser>>>();

            var userManagerMock = new Mock<UserManager<IdentityUser>>(
                userStore,
                identityOptions,
                passwordHasher,
                userValidators,
                passwordValidators,
                keyNormalizer,
                errors,
                services,
                loggerUserManager
            );

            userManagerMock.Setup(x => x.CreateAsync(It.IsAny<IdentityUser>(), It.IsAny<string>()))
                .ReturnsAsync(IdentityResult.Success); // Mock the CreateAsync method to return success

            return new AdminController(userManagerMock.Object, logger, userRepository);
        }
        
        [Fact]
        public async Task IndexReturnsCorrectModelType()
        {
            var unitUnderTest = GetUnitUnderTest();
            var result = unitUnderTest.Index(email: "Test@mail.com") as ViewResult;
            Assert.IsType<UserViewModel>(result.Model);
            var userModel = result.Model as UserViewModel;
            Assert.NotNull(userModel);
            Assert.Equal("Test@mail.com", userModel.Email);
        }

        [Fact]
        public async Task UserManagerIsCalledOnRegister()
        {

            var controller = GetUnitUnderTest();
            var model = new RegisterViewModel { Email = "test@example.com", Password = "password" };


            var result = await controller.Register(model);


            Assert.IsType<RedirectToActionResult>(result);
            var redirectResult = result as RedirectToActionResult;
            Assert.Equal("Oversikt", redirectResult.ActionName);
        }
        [Fact]
        public async Task DeleteReturnsRedirectToActionResult()
        {
            var controller = GetUnitUnderTest();
            var Email = "Test@mail.com";
            var result = controller.Delete(Email) as RedirectToActionResult;
            Assert.NotNull(result);
            Assert.Equal("Oversikt", result.ActionName);
        }

    }
}
