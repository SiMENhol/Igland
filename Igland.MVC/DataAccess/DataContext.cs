using Igland.MVC.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Igland.MVC.DataAccess
{
    public class DataContext : IdentityDbContext<IdentityUser>
    {

        /// <summary>
        /// Creates DataContext inherits from IdentityDbContext<IdentityUser> for database use, interacts with Program.cs eller files in map "Repositories"
        /// Parameters configuret how DataContext interacts with the database, interacts with Program.cs eller files in map "Repositories"
        /// </summary>
        /// <param name="options"> instance of DbContextOptions<DataContext></param>
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }


        /// <summary>
        /// Provides configuration for database.
        /// modelBuilder.Entity returns object to configure partly how that entity type maps to  database.
        /// Specifies name of the table to which the entity type should be mapped.
        /// .HasKey method spesifies primary key of the entitiy
        /// base.OnModelCreating(modelBuilder) calls IdentityDbContext<IdentityUser> to apply base configuration first
        /// </summary>
        /// <param name="modelBuilder"> defines the mappings between entities and db tables</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserEntity>().ToTable("aspnetusers").HasKey(x => x.Id);
            modelBuilder.Entity<ServiceDokumentEntity>().ToTable("ServiceDokument").HasKey(x => x.ServiceSkjemaID);
            modelBuilder.Entity<ArbDok>().ToTable("ArbDok").HasKey(x => x.ArbDokID);
            modelBuilder.Entity<OrdreEntity>().ToTable("Ordre").HasKey(x => x.OrdreNummer);
            modelBuilder.Entity<KunderEntity>().ToTable("Kunder").HasKey(x => x.KundeID);
            modelBuilder.Entity<SjekklisteEntity>().ToTable("Sjekkliste").HasKey(x => x.SjekklisteID);
            modelBuilder.Entity<SjekklisteItemEntity>().ToTable("SjekklisteItem").HasKey(x => x.SjekklisteItemID);
            base.OnModelCreating(modelBuilder);
        }



        /// <summary>
        /// Entities used for configuration in OnModelCreating Method
        /// </summary>
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<ServiceDokumentEntity> ServiceDokument { get; set; }
        public DbSet<ArbDok> ArbDok { get; set; }
        public DbSet<OrdreEntity> Ordre { get; set; }
        public DbSet<KunderEntity> Kunder { get; set; }
        public DbSet<SjekklisteEntity> Sjekkliste { get; set; }
        public DbSet<SjekklisteItemEntity> SjekklisteItem { get; set; }
    }
}