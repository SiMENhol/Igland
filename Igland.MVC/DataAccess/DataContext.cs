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
            modelBuilder.Entity<UserEntity>().ToTable("aspnetusers").HasKey(x => x.Id);
            modelBuilder.Entity<ServiceDokumentEntity>().ToTable("ServiceSkjema").HasKey(x => x.ServiceSkjemaID);
            modelBuilder.Entity<ArbDok>().ToTable("ArbDok").HasKey(x => x.ArbDokID);
            modelBuilder.Entity<OrdreEntity>().ToTable("Ordre").HasKey(x => x.OrdreNummer);
            modelBuilder.Entity<KunderEntity>().ToTable("Kunder").HasKey(x => x.KundeID);
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<UserEntity> Users { get; set; }
        public DbSet<ServiceDokumentEntity> ServiceDokuments { get; set; }
        public DbSet<ArbDok> ArbDok { get; set; }
        public DbSet<OrdreEntity> Ordre { get; set; }
        public DbSet<KunderEntity> Kunder { get; set; }
    }
}