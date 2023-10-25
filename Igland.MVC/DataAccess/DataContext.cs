using Igland.MVC.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Igland.MVC.DataAccess
{
    public class DataContext : IdentityDbContext<IdentityUser>
    {
        public DataContext()
        {
        }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserEntity>().ToTable("Users").HasKey(x => x.Id);
            modelBuilder.Entity<ServiceDocs>().ToTable("ServiceSkjema").HasKey(x => x.ServiceSkjemaID);
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<UserEntity> Users { get; set; }
        public DbSet<ServiceDocs> Services { get; set; }
    }
}
