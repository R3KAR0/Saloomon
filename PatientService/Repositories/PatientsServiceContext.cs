using Microsoft.EntityFrameworkCore;
using PatientServiceModels;
using PatientServiceModels.NewApproach;


namespace PatientService.Repositories
{
    public class PatientsServiceContext : DbContext
    {
        public DbSet<Patient> Patients { get; set; }
        public DbSet<TopLevelDocument> TopDocuments { get; set; }
        public DbSet<SubLevelDocument> SubDocuments { get; set; }
        public DbSet<PatientFolder> PatientFolders { get; set; }
        public DbSet<TopLevelFolder> TopLevelFolders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Startup.Configuration["SqlConnectionString"]);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*
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
            */

            modelBuilder.Entity<Patient>()
                .HasMany(patient => patient.PatientDocuments)
                .WithOne(document => document.Parent);

            modelBuilder.Entity<Patient>()
                .HasMany(patient => patient.PatientFolders)
                .WithOne(folder => folder.Parent);



            modelBuilder.Entity<TopLevelFolder>()
                .HasMany(topFolder => topFolder.SubFolders)
                .WithOne(subFolder => subFolder.ParentFolder);

            modelBuilder.Entity<TopLevelFolder>()
                .HasMany(topFolder => topFolder.Patients)
                .WithOne(patient => patient.ParentFolder);

            modelBuilder.Entity<TopLevelFolder>()
                .HasMany(topFolder => topFolder.SubDocuments)
                .WithOne(document => document.Parent);



            modelBuilder.Entity<TopFolderDocument>()
                .HasMany(tfd => tfd.SubDocuments)
                .WithOne(subdoc => subdoc.Parent);

            modelBuilder.Entity<PatientTopDocument>()
                .HasMany(ptd => ptd.SubDocuments)
                .WithOne(subDoc => subDoc.Parent);

            modelBuilder.Entity<PatientFolderDocument>()
                .HasMany(pfd => pfd.SubDocuments)
                .WithOne(subDoc => subDoc.Parent);


            modelBuilder.Entity<PatientFolder>()
                .HasMany(patientFolder => patientFolder.SubDocuments)
                .WithOne(patientDocument => patientDocument.Parent);
     


        }
    }
}
