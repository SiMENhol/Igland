using Igland.MVC.DataAccess;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.UI.Services;
using Igland.MVC.Repositories.EF;
using Igland.MVC.Repositories.IRepo;
using Microsoft.AspNetCore.Authorization;
using Igland.MVC;
using Microsoft.AspNetCore;

public class Program
{
    static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllersWithViews();
        
        SetupDataConnections(builder);

        SetupAuthentication(builder);

        // Define a global authorization policy that requires authentication
        builder.Services.AddAuthorization(options =>
        {
            options.FallbackPolicy = new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser()
                .Build();
        });

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseStaticFiles();

        app.UseRouting();

        UseAuthentication(app);

        app.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");
        app.MapControllers();

        WebHost.CreateDefaultBuilder(args)
        .ConfigureKestrel(c => c.AddServerHeader = false)
        .UseStartup<Startup>()
        .Build();

        app.Run();



    }

    private static void SetupDataConnections(WebApplicationBuilder builder)
    {
        builder.Services.AddTransient<ISqlConnector, SqlConnector>();

        builder.Services.AddDbContext<DataContext>(options =>
        {
            options.UseMySql(builder.Configuration.GetConnectionString("MariaDb"), ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("MariaDb")));
        });
        builder.Services.AddScoped<IUserRepository, EFUserRepository>();
        builder.Services.AddScoped<ISjekklisteRepository, EFSjekkliste>();
        builder.Services.AddScoped<IArbDokRepository, EFArbDokRepository>();
        builder.Services.AddScoped<IServiceDokumentRepository, EFServiceDokument>();
        builder.Services.AddScoped<IOrdreRepository, EFOrdre>();
        builder.Services.AddScoped<IKunderRepository, EFKunder>();
    }

    private static void UseAuthentication(WebApplication app)
    {
        app.UseAuthentication();
        app.UseAuthorization();
    }

    private static void SetupAuthentication(WebApplicationBuilder builder)
    {
        //Setup for Authentication
        builder.Services.Configure<IdentityOptions>(options =>
        {
            // Default Lockout settings.
            options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
            options.Lockout.MaxFailedAccessAttempts = 5;
            options.Lockout.AllowedForNewUsers = false;
            options.SignIn.RequireConfirmedPhoneNumber = false;
            options.SignIn.RequireConfirmedEmail = false;
            options.SignIn.RequireConfirmedAccount = false;
            options.User.RequireUniqueEmail = true;
        });

        builder.Services
            .AddIdentityCore<IdentityUser>()
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<DataContext>()
            .AddSignInManager()
            .AddDefaultTokenProviders();

        builder.Services.AddAuthentication(o =>
        {
            o.DefaultScheme = IdentityConstants.ApplicationScheme;
            o.DefaultSignInScheme = IdentityConstants.ExternalScheme;

        }).AddIdentityCookies(o => {
            if (o.ApplicationCookie != null)
            {
                o.ApplicationCookie.Configure(o => o.LoginPath = "/Account/Login");
            }
        });

        builder.Services.AddTransient<IEmailSender, AuthMessageSender>();
    }

    public class AuthMessageSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            Console.WriteLine(email);
            Console.WriteLine(subject);
            Console.WriteLine(htmlMessage);
            return Task.CompletedTask;
        }
    }
}