﻿using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace DataAccess.Context
{
    public class BetterCalmContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Playlist> Playlists { get; set; }
        public DbSet<CategoryPlaylist> CategoryPlaylists { get; set; }
        public DbSet<Psychologist> Psychologists { get; set; }

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

            modelBuilder.Entity<Playlist>().ToTable("Playlists");
            modelBuilder.Entity<Playlist>().HasKey(s => s.Id);
            modelBuilder.Entity<Playlist>().Property(s => s.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Playlist>().HasMany(s => s.Categories);

            modelBuilder.Entity<CategoryPlaylist>().ToTable("CategoryPlaylists");
            modelBuilder.Entity<CategoryPlaylist>().HasKey(cp => new { cp.CategoryId, cp.PlaylistId });
            modelBuilder.Entity<CategoryPlaylist>().HasOne(s => s.Category).WithMany(p => p.Playlists).HasForeignKey(sc => sc.CategoryId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<CategoryPlaylist>().HasOne(s => s.Playlist).WithMany(p => p.Categories).HasForeignKey(sc => sc.PlaylistId).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Psychologist>().ToTable("Psychologists");
            modelBuilder.Entity<Psychologist>().HasKey(p => p.Id);
            modelBuilder.Entity<Psychologist>().Property(p => p.Name).IsRequired();
            modelBuilder.Entity<Psychologist>().Property(p => p.ConsultationMode).IsRequired();
            modelBuilder.Entity<Psychologist>().Property(p => p.Direction).IsRequired();
            modelBuilder.Entity<Psychologist>().Property(s => s.Id).ValueGeneratedOnAdd();
        }
    }
}