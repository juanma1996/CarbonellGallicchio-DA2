// <auto-generated />
using System;
using DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataAccess.Migrations
{
    [DbContext(typeof(BetterCalmContext))]
    [Migration("20210423215055_AudioContentCategory_AudioContentPlaylist_IntermediateTables")]
    partial class AudioContentCategory_AudioContentPlaylist_IntermediateTables
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Domain.AudioContent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AudioUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreatorName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<TimeSpan>("Duration")
                        .HasColumnType("time");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AudioContents");
                });

            modelBuilder.Entity("Domain.AudioContentCategory", b =>
                {
                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<int>("AudioContentId")
                        .HasColumnType("int");

                    b.HasKey("CategoryId", "AudioContentId");

                    b.HasIndex("AudioContentId");

                    b.ToTable("AudioContentCategories");
                });

            modelBuilder.Entity("Domain.AudioContentPlaylist", b =>
                {
                    b.Property<int>("AudioContentId")
                        .HasColumnType("int");

                    b.Property<int>("PlaylistId")
                        .HasColumnType("int");

                    b.HasKey("AudioContentId", "PlaylistId");

                    b.HasIndex("PlaylistId");

                    b.ToTable("AudioContentPlaylists");
                });

            modelBuilder.Entity("Domain.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Domain.CategoryPlaylist", b =>
                {
                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<int>("PlaylistId")
                        .HasColumnType("int");

                    b.HasKey("CategoryId", "PlaylistId");

                    b.HasIndex("PlaylistId");

                    b.ToTable("CategoryPlaylists");
                });

            modelBuilder.Entity("Domain.Playlist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("Id");

                    b.ToTable("Playlists");
                });

            modelBuilder.Entity("Domain.AudioContentCategory", b =>
                {
                    b.HasOne("Domain.AudioContent", "AudioContent")
                        .WithMany("Categories")
                        .HasForeignKey("AudioContentId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Domain.Category", "Category")
                        .WithMany("AudioContents")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.AudioContentPlaylist", b =>
                {
                    b.HasOne("Domain.AudioContent", "AudioContent")
                        .WithMany("Playlists")
                        .HasForeignKey("AudioContentId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Domain.Playlist", "Playlist")
                        .WithMany("AudioContents")
                        .HasForeignKey("PlaylistId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.CategoryPlaylist", b =>
                {
                    b.HasOne("Domain.Category", "Category")
                        .WithMany("Playlists")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Domain.Playlist", "Playlist")
                        .WithMany("Categories")
                        .HasForeignKey("PlaylistId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
