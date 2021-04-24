using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
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

        public BetterCalmContext() { }
        public BetterCalmContext(DbContextOptions options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string directory = Directory.GetCurrentDirectory();

                IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(directory)
                .AddJsonFile("appsettings.json")
                .Build();

                var connectionString = configuration.GetConnectionString(@"BetterCalmDB");

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

            modelBuilder.Entity<Playlist>().ToTable("Playlists");
            modelBuilder.Entity<Playlist>().HasKey(s => s.Id);
            modelBuilder.Entity<Playlist>().Property(s => s.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Playlist>().HasMany(s => s.Categories);
            modelBuilder.Entity<Playlist>().HasMany(s => s.AudioContents);

            modelBuilder.Entity<AudioContent>().ToTable("AudioContents");
            modelBuilder.Entity<AudioContent>().HasKey(s => s.Id);
            modelBuilder.Entity<AudioContent>().Property(p => p.Name).IsRequired();
            modelBuilder.Entity<AudioContent>().Property(s => s.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<AudioContent>().HasMany(s => s.Categories);
            modelBuilder.Entity<AudioContent>().HasMany(s => s.Playlists);

            modelBuilder.Entity<CategoryPlaylist>().ToTable("CategoryPlaylists");
            modelBuilder.Entity<CategoryPlaylist>().HasKey(cp => new { cp.CategoryId, cp.PlaylistId });
            modelBuilder.Entity<CategoryPlaylist>().HasOne(s => s.Category).WithMany(p => p.Playlists).HasForeignKey(sc => sc.CategoryId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<CategoryPlaylist>().HasOne(s => s.Playlist).WithMany(p => p.Categories).HasForeignKey(sc => sc.PlaylistId).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<AudioContentCategory>().ToTable("AudioContentCategories");
            modelBuilder.Entity<AudioContentCategory>().HasKey(cp => new { cp.CategoryId, cp.AudioContentId });
            modelBuilder.Entity<AudioContentCategory>().HasOne(s => s.Category).WithMany(p => p.AudioContents).HasForeignKey(sc => sc.CategoryId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<AudioContentCategory>().HasOne(s => s.AudioContent).WithMany(p => p.Categories).HasForeignKey(sc => sc.AudioContentId).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<AudioContentPlaylist>().ToTable("AudioContentPlaylists");
            modelBuilder.Entity<AudioContentPlaylist>().HasKey(cp => new { cp.AudioContentId, cp.PlaylistId });
            modelBuilder.Entity<AudioContentPlaylist>().HasOne(s => s.AudioContent).WithMany(p => p.Playlists).HasForeignKey(sc => sc.AudioContentId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<AudioContentPlaylist>().HasOne(s => s.Playlist).WithMany(p => p.AudioContents).HasForeignKey(sc => sc.PlaylistId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}