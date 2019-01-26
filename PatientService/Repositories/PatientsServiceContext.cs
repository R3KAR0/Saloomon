using Microsoft.EntityFrameworkCore;
using PatientService.Models;
using PatientServiceModels;


namespace PatientService.Repositories
{
    public class PatientsServiceContext : DbContext
    {
        public DbSet<Patient> Patients { get; set; }
        public DbSet<StudyFolder> StudyFolders { get; set; }
        public DbSet<Document> Documents { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Startup.Configuration["SqlConnectionString"]);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patient>()
                .HasMany<Document>()
                .WithOne(d => (Patient)d.Parent)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Patient>()
                .HasMany<StudyFolder>()
                .WithOne(d => (Patient)d.Parent)
             
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<StudyFolder>()
                .HasMany(sf => sf.Documents)
                .WithOne(d => (StudyFolder) d.Parent)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<StudyFolder>()
                .HasMany(sf => sf.SubFolders)
                .WithOne(d => (StudyFolder)d.Parent)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<StudyFolder>()
                .HasMany(sf => sf.Patients)
                .WithOne(d => d.Parent)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Document>()
                .HasMany(d => d.FollowUps)
                .WithOne(d => (Document) d.Parent)
                .OnDelete(DeleteBehavior.Cascade);



        }
    }
}
