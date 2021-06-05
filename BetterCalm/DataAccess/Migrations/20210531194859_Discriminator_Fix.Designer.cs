﻿// <auto-generated />
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
    [Migration("20210531194859_Discriminator_Fix")]
    partial class Discriminator_Fix
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Domain.Administrator", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Administrators");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "admin@gmail.com",
                            Name = "SuperAdmin",
                            Password = "1234"
                        });
                });

            modelBuilder.Entity("Domain.Agenda", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsAvaible")
                        .HasColumnType("bit");

                    b.Property<int?>("PsychologistId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PsychologistId");

                    b.ToTable("Agendas");
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

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Dormir"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Meditar"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Música"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Cuerpo"
                        });
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

            modelBuilder.Entity("Domain.Consultation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("PacientId")
                        .HasColumnType("int");

                    b.Property<int>("ProblematicId")
                        .HasColumnType("int");

                    b.Property<int?>("PsychologistId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PacientId");

                    b.HasIndex("PsychologistId");

                    b.ToTable("Consultations");
                });

            modelBuilder.Entity("Domain.Pacient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Cellphone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Pacients");
                });

            modelBuilder.Entity("Domain.PlayableContent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatorName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<TimeSpan>("Duration")
                        .HasColumnType("time");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PlayableContents");

                    b.HasDiscriminator<string>("Discriminator").HasValue("PlayableContent");
                });

            modelBuilder.Entity("Domain.PlayableContentCategory", b =>
                {
                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<int>("PlayableContentId")
                        .HasColumnType("int");

                    b.HasKey("CategoryId", "PlayableContentId");

                    b.HasIndex("PlayableContentId");

                    b.ToTable("AudioContentCategories");
                });

            modelBuilder.Entity("Domain.PlayableContentPlaylist", b =>
                {
                    b.Property<int>("PlayableContentId")
                        .HasColumnType("int");

                    b.Property<int>("PlaylistId")
                        .HasColumnType("int");

                    b.HasKey("PlayableContentId", "PlaylistId");

                    b.HasIndex("PlaylistId");

                    b.ToTable("AudioContentPlaylists");
                });

            modelBuilder.Entity("Domain.Playlist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(150)")
                        .HasMaxLength(150);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Playlists");
                });

            modelBuilder.Entity("Domain.Problematic", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Problematics");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Depresión"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Estrés"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Ansiedad"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Autoestima"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Enojo"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Relaciones"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Duelo"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Otros"
                        });
                });

            modelBuilder.Entity("Domain.Psychologist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ConsultationMode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Direction")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Psychologists");
                });

            modelBuilder.Entity("Domain.PsychologistProblematic", b =>
                {
                    b.Property<int>("PsychologistId")
                        .HasColumnType("int");

                    b.Property<int>("ProblematicId")
                        .HasColumnType("int");

                    b.HasKey("PsychologistId", "ProblematicId");

                    b.HasIndex("ProblematicId");

                    b.ToTable("PsychologistProblematics");
                });

            modelBuilder.Entity("Domain.Session", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AdministratorId")
                        .HasColumnType("int");

                    b.Property<Guid>("Token")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("AdministratorId");

                    b.ToTable("Sessions");
                });

            modelBuilder.Entity("Domain.AudioContent", b =>
                {
                    b.HasBaseType("Domain.PlayableContent");

                    b.HasDiscriminator().HasValue("AudioContent");
                });

            modelBuilder.Entity("Domain.VideoContent", b =>
                {
                    b.HasBaseType("Domain.PlayableContent");

                    b.HasDiscriminator().HasValue("VideoContent");
                });

            modelBuilder.Entity("Domain.Agenda", b =>
                {
                    b.HasOne("Domain.Psychologist", "Psychologist")
                        .WithMany()
                        .HasForeignKey("PsychologistId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Domain.CategoryPlaylist", b =>
                {
                    b.HasOne("Domain.Category", "Category")
                        .WithMany("Playlists")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Playlist", "Playlist")
                        .WithMany("Categories")
                        .HasForeignKey("PlaylistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Consultation", b =>
                {
                    b.HasOne("Domain.Pacient", "Pacient")
                        .WithMany()
                        .HasForeignKey("PacientId");

                    b.HasOne("Domain.Psychologist", "Psychologist")
                        .WithMany()
                        .HasForeignKey("PsychologistId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Domain.PlayableContentCategory", b =>
                {
                    b.HasOne("Domain.Category", "Category")
                        .WithMany("AudioContents")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.PlayableContent", "PlayableContent")
                        .WithMany("Categories")
                        .HasForeignKey("PlayableContentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.PlayableContentPlaylist", b =>
                {
                    b.HasOne("Domain.PlayableContent", "PlayableContent")
                        .WithMany("Playlists")
                        .HasForeignKey("PlayableContentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Playlist", "Playlist")
                        .WithMany("AudioContents")
                        .HasForeignKey("PlaylistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.PsychologistProblematic", b =>
                {
                    b.HasOne("Domain.Problematic", "Problematic")
                        .WithMany("Psychologists")
                        .HasForeignKey("ProblematicId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Psychologist", "Psychologist")
                        .WithMany("Problematics")
                        .HasForeignKey("PsychologistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Session", b =>
                {
                    b.HasOne("Domain.Administrator", "Administrator")
                        .WithMany()
                        .HasForeignKey("AdministratorId");
                });
#pragma warning restore 612, 618
        }
    }
}
