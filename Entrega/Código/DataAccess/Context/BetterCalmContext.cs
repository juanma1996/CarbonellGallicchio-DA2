using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Diagnostics.CodeAnalysis;
using System.IO;

namespace DataAccess.Context
{
    public class BetterCalmContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Playlist> Playlists { get; set; }
        public DbSet<AudioContent> AudioContents { get; set; }
        public DbSet<CategoryPlaylist> CategoryPlaylists { get; set; }
        public DbSet<AudioContentCategory> AudioContentCategories { get; set; }
        public DbSet<AudioContentPlaylist> AudioContentPlaylists { get; set; }
        public DbSet<Psychologist> Psychologists { get; set; }
        public DbSet<Problematic> Problematics { get; set; }
        public DbSet<PsychologistProblematic> PsychologistProblematics { get; set; }
        public DbSet<Administrator> Administrators { get; set; }
        public DbSet<Pacient> Pacients { get; set; }
        public DbSet<Consultation> Consultations { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<Agenda> Agendas { get; set; }

        public BetterCalmContext() { }
        public BetterCalmContext(DbContextOptions options) : base(options) { }

        [ExcludeFromCodeCoverage]
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string directory = Directory.GetCurrentDirectory();

                IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(directory)
                .AddJsonFile("appsettings.json")
                .Build();

                string connectionString = configuration.GetConnectionString(@"BetterCalmDB");

                optionsBuilder.UseSqlServer(connectionString);
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().ToTable("Categories");
            modelBuilder.Entity<Category>().HasKey(s => s.Id);
            modelBuilder.Entity<Category>().Property(s => s.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Category>().HasMany(s => s.Playlists);
            modelBuilder.Entity<Category>().HasMany(s => s.AudioContents);
            modelBuilder.Entity<Category>().HasData(new Category() { Id = 1, Name = "Dormir" });
            modelBuilder.Entity<Category>().HasData(new Category() { Id = 2, Name = "Meditar" });
            modelBuilder.Entity<Category>().HasData(new Category() { Id = 3, Name = "Música" });
            modelBuilder.Entity<Category>().HasData(new Category() { Id = 4, Name = "Cuerpo" });

            modelBuilder.Entity<Playlist>().ToTable("Playlists");
            modelBuilder.Entity<Playlist>().HasKey(s => s.Id);
            modelBuilder.Entity<Playlist>().Property(s => s.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Playlist>().HasMany(s => s.Categories);
            modelBuilder.Entity<Playlist>().HasMany(s => s.AudioContents);
            modelBuilder.Entity<Playlist>().Property(p => p.Name).IsRequired();
            modelBuilder.Entity<Playlist>().Property(p => p.Description).IsRequired();
            modelBuilder.Entity<Playlist>().Property(p => p.Description).HasMaxLength(150);

            modelBuilder.Entity<AudioContent>().ToTable("AudioContents");
            modelBuilder.Entity<AudioContent>().HasKey(s => s.Id);
            modelBuilder.Entity<AudioContent>().Property(p => p.Name).IsRequired();
            modelBuilder.Entity<AudioContent>().Property(s => s.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<AudioContent>().HasMany(s => s.Categories);
            modelBuilder.Entity<AudioContent>().HasMany(s => s.Playlists);

            modelBuilder.Entity<CategoryPlaylist>().ToTable("CategoryPlaylists");
            modelBuilder.Entity<CategoryPlaylist>().HasKey(cp => new { cp.CategoryId, cp.PlaylistId });
            modelBuilder.Entity<CategoryPlaylist>().HasOne(s => s.Category).WithMany(p => p.Playlists).HasForeignKey(sc => sc.CategoryId).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<CategoryPlaylist>().HasOne(s => s.Playlist).WithMany(p => p.Categories).HasForeignKey(sc => sc.PlaylistId).OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<AudioContentCategory>().ToTable("AudioContentCategories");
            modelBuilder.Entity<AudioContentCategory>().HasKey(cp => new { cp.CategoryId, cp.AudioContentId });
            modelBuilder.Entity<AudioContentCategory>().HasOne(s => s.Category).WithMany(p => p.AudioContents).HasForeignKey(sc => sc.CategoryId).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<AudioContentCategory>().HasOne(s => s.AudioContent).WithMany(p => p.Categories).HasForeignKey(sc => sc.AudioContentId).OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<AudioContentPlaylist>().ToTable("AudioContentPlaylists");
            modelBuilder.Entity<AudioContentPlaylist>().HasKey(cp => new { cp.AudioContentId, cp.PlaylistId });
            modelBuilder.Entity<AudioContentPlaylist>().HasOne(s => s.AudioContent).WithMany(p => p.Playlists).HasForeignKey(sc => sc.AudioContentId).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<AudioContentPlaylist>().HasOne(s => s.Playlist).WithMany(p => p.AudioContents).HasForeignKey(sc => sc.PlaylistId).OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Psychologist>().ToTable("Psychologists");
            modelBuilder.Entity<Psychologist>().HasKey(p => p.Id);
            modelBuilder.Entity<Psychologist>().Property(p => p.Name).IsRequired();
            modelBuilder.Entity<Psychologist>().Property(p => p.ConsultationMode).IsRequired();
            modelBuilder.Entity<Psychologist>().Property(p => p.Direction).IsRequired();
            modelBuilder.Entity<Psychologist>().Property(s => s.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Psychologist>().HasMany(p => p.Problematics);

            modelBuilder.Entity<Problematic>().ToTable("Problematics");
            modelBuilder.Entity<Problematic>().HasKey(p => p.Id);
            modelBuilder.Entity<Problematic>().Property(p => p.Name).IsRequired();
            modelBuilder.Entity<Problematic>().Property(p => p.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Problematic>().HasMany(p => p.Psychologists);
            modelBuilder.Entity<Problematic>().HasData(new Problematic() { Id = 1, Name = "Depresión" });
            modelBuilder.Entity<Problematic>().HasData(new Problematic() { Id = 2, Name = "Estrés" });
            modelBuilder.Entity<Problematic>().HasData(new Problematic() { Id = 3, Name = "Ansiedad" });
            modelBuilder.Entity<Problematic>().HasData(new Problematic() { Id = 4, Name = "Autoestima" });
            modelBuilder.Entity<Problematic>().HasData(new Problematic() { Id = 5, Name = "Enojo" });
            modelBuilder.Entity<Problematic>().HasData(new Problematic() { Id = 6, Name = "Relaciones" });
            modelBuilder.Entity<Problematic>().HasData(new Problematic() { Id = 7, Name = "Duelo" });
            modelBuilder.Entity<Problematic>().HasData(new Problematic() { Id = 8, Name = "Otros" });

            modelBuilder.Entity<PsychologistProblematic>().ToTable("PsychologistProblematics");
            modelBuilder.Entity<PsychologistProblematic>().HasKey(pp => new { pp.PsychologistId, pp.ProblematicId });
            modelBuilder.Entity<PsychologistProblematic>().HasOne<Psychologist>(p => p.Psychologist).WithMany(pr => pr.Problematics).HasForeignKey(sc => sc.PsychologistId).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<PsychologistProblematic>().HasOne<Problematic>(p => p.Problematic).WithMany(pr => pr.Psychologists).HasForeignKey(sc => sc.ProblematicId).OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Consultation>().ToTable("Consultations");
            modelBuilder.Entity<Consultation>().HasKey(p => p.Id);
            modelBuilder.Entity<Consultation>().Property(p => p.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Consultation>().HasOne(p => p.Psychologist).WithMany().OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Consultation>().HasOne(p => p.Pacient);

            modelBuilder.Entity<Pacient>().ToTable("Pacients");
            modelBuilder.Entity<Pacient>().HasKey(p => p.Id);

            modelBuilder.Entity<Session>().ToTable("Sessions");
            modelBuilder.Entity<Session>().HasKey(p => p.Id);
            modelBuilder.Entity<Session>().Property(p => p.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Session>().HasOne(p => p.Administrator);

            modelBuilder.Entity<Agenda>().ToTable("Agendas");
            modelBuilder.Entity<Agenda>().HasKey(p => p.Id);
            modelBuilder.Entity<Agenda>().Property(p => p.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Agenda>().HasOne(p => p.Psychologist).WithMany().OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Administrator>().ToTable("Administrators");
            modelBuilder.Entity<Administrator>().HasKey(s => s.Id);
            modelBuilder.Entity<Administrator>().Property(p => p.Name).IsRequired();
            modelBuilder.Entity<Administrator>().Property(p => p.Email).IsRequired();
            modelBuilder.Entity<Administrator>().Property(p => p.Password).IsRequired();
            modelBuilder.Entity<Administrator>().Property(s => s.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Administrator>().HasData(new Administrator() { Id = 1, Name = "SuperAdmin",
                Email = "admin@gmail.com", Password="1234" });
        }
    }
}