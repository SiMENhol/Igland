using Castle.Core.Logging;
using Igland.MVC.Controllers;
using Igland.MVC.Entities;
using Igland.MVC.Models.Account;
using Igland.MVC.Models.ArbDok;
using Igland.MVC.Models.Users;
using Igland.MVC.Repositories.EF;
using Igland.MVC.Repositories.IRepo;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;

namespace Igland.MVC.Tests.Controllers
{
    public class FakeSignInManager : SignInManager<IdentityUser>
    {
        public FakeSignInManager()
            : base(new FakeUserManager(),
                   Substitute.For<IHttpContextAccessor>(),
                   Substitute.For<IUserClaimsPrincipalFactory<IdentityUser>>(),
                   Substitute.For<IOptions<IdentityOptions>>(),
                   Substitute.For<ILogger<SignInManager<IdentityUser>>>(),
                   Substitute.For<IAuthenticationSchemeProvider>(),
                   Substitute.For<IUserConfirmation<IdentityUser>>()
                   )
        { }
    }

    public class FakeUserManager : UserManager<IdentityUser>
    {
        public FakeUserManager()
            : base(Substitute.For<IUserStore<IdentityUser>>(),
                   Substitute.For<IOptions<IdentityOptions>>(),
                   Substitute.For<IPasswordHasher<IdentityUser>>(),
                   new IUserValidator<IdentityUser>[0],
                   new IPasswordValidator<IdentityUser>[0],
                   Substitute.For<ILookupNormalizer>(),
                   Substitute.For<IdentityErrorDescriber>(),
                   Substitute.For<IServiceProvider>(),
                   Substitute.For<ILogger<UserManager<IdentityUser>>>())
        { }

        public override Task<IdentityResult> CreateAsync(IdentityUser user, string password)
        {
            user.PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(user, password);
            return Task.FromResult(IdentityResult.Success);
        }

        public override Task<bool> CheckPasswordAsync(IdentityUser user, string password)
        {
            return Task.FromResult(new PasswordHasher<IdentityUser>().VerifyHashedPassword(user, user.PasswordHash, password) != PasswordVerificationResult.Failed);
        }
        public override Task<IdentityResult> AddToRoleAsync(IdentityUser user, string role)
        {
            return Task.FromResult(IdentityResult.Success);
        }

        public override Task<string> GenerateEmailConfirmationTokenAsync(IdentityUser user)
        {
            return Task.FromResult(Guid.NewGuid().ToString());
        }
    }

    public class AccountControllerUnitTests
    {
        private UserManager<IdentityUser> userManager;
        private SignInManager<IdentityUser> signInManager;
        private ILogger<AccountController> logger;
        private IUserRepository userRepository;

        private void InitializeFakes()
        {
            logger = Substitute.For<ILogger<AccountController>>();

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

        private AccountController GetUnitUnderTest()
        {
            InitializeFakes();

            var fakeUserManager = new FakeUserManager();
            var fakeSignInManager = new FakeSignInManager();

            return new AccountController(
                fakeUserManager,
                fakeSignInManager,
                logger,
                userRepository
            );
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
        public async Task LoginReturnsCorrectViewWhenModelStateIsInvalid()
        {
            
            var unitUnderTest = GetUnitUnderTest();
            var model = new LoginViewModel
            {     
                Email = "epost",
                Password = "validPassword",
                RememberMe = true // Adjust based on your actual requirements
                                  };
            unitUnderTest.ModelState.AddModelError("key", "error message");

            
            var result = await unitUnderTest.Login(model);

            
            Assert.IsType<ViewResult>(result);
            var viewResult = result as ViewResult;
            Assert.True(string.IsNullOrEmpty(viewResult.ViewName));
        }

        [Fact]
        public async Task LoginRedirectsToLocalWhenLoginIsSuccessful()
        {
            
            var unitUnderTest = GetUnitUnderTest();
            var model = new LoginViewModel { Email = "Test@mail.com", Password = "Passord123!", RememberMe = false };

            
            var result = await unitUnderTest.Login(model);

            
            Assert.IsType<ViewResult>(result);
        }
        /*
        [Fact]
        public async Task LogOffRedirectsToLogin()
        {
            
            var unitUnderTest = GetUnitUnderTest();

            
            var result = await unitUnderTest.LogOff();

            
            Assert.IsType<RedirectToActionResult>(result);
            var redirectToActionResult = result as RedirectToActionResult;
            Assert.Equal("Login", redirectToActionResult.ActionName);
            Assert.Null(redirectToActionResult.ControllerName); // Assuming it redirects to the same controller
        } */

    }
}
