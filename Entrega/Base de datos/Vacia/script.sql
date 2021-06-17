USE [master]
GO
/****** Object:  Database [BetterCalmDB]    Script Date: 6/17/2021 6:23:35 PM ******/
CREATE DATABASE [BetterCalmDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BetterCalmDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\BetterCalmDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'BetterCalmDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\BetterCalmDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [BetterCalmDB] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BetterCalmDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BetterCalmDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BetterCalmDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BetterCalmDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BetterCalmDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BetterCalmDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [BetterCalmDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [BetterCalmDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BetterCalmDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BetterCalmDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BetterCalmDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BetterCalmDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BetterCalmDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BetterCalmDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BetterCalmDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BetterCalmDB] SET  ENABLE_BROKER 
GO
ALTER DATABASE [BetterCalmDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BetterCalmDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BetterCalmDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BetterCalmDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BetterCalmDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BetterCalmDB] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [BetterCalmDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BetterCalmDB] SET RECOVERY FULL 
GO
ALTER DATABASE [BetterCalmDB] SET  MULTI_USER 
GO
ALTER DATABASE [BetterCalmDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BetterCalmDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BetterCalmDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BetterCalmDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [BetterCalmDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [BetterCalmDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'BetterCalmDB', N'ON'
GO
ALTER DATABASE [BetterCalmDB] SET QUERY_STORE = OFF
GO
USE [BetterCalmDB]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 6/17/2021 6:23:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Administrators]    Script Date: 6/17/2021 6:23:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Administrators](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
	[Password] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Administrators] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Agendas]    Script Date: 6/17/2021 6:23:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Agendas](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PsychologistId] [int] NULL,
	[Date] [datetime2](7) NOT NULL,
	[Count] [int] NOT NULL,
	[IsAvaible] [bit] NOT NULL,
 CONSTRAINT [PK_Agendas] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 6/17/2021 6:23:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CategoryPlaylists]    Script Date: 6/17/2021 6:23:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CategoryPlaylists](
	[CategoryId] [int] NOT NULL,
	[PlaylistId] [int] NOT NULL,
 CONSTRAINT [PK_CategoryPlaylists] PRIMARY KEY CLUSTERED 
(
	[CategoryId] ASC,
	[PlaylistId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Consultations]    Script Date: 6/17/2021 6:23:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Consultations](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProblematicId] [int] NOT NULL,
	[PacientId] [int] NULL,
	[PsychologistId] [int] NULL,
	[Cost] [decimal](18, 2) NOT NULL,
	[Duration] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_Consultations] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pacients]    Script Date: 6/17/2021 6:23:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pacients](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Surname] [nvarchar](max) NULL,
	[BirthDate] [datetime2](7) NOT NULL,
	[Email] [nvarchar](max) NULL,
	[Cellphone] [nvarchar](max) NULL,
	[BonusAmount] [decimal](18, 2) NOT NULL,
	[BonusApproved] [bit] NOT NULL,
	[ConsultationsQuantity] [int] NOT NULL,
	[GeneratedBonus] [bit] NOT NULL,
 CONSTRAINT [PK_Pacients] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PlayableContentCategories]    Script Date: 6/17/2021 6:23:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PlayableContentCategories](
	[CategoryId] [int] NOT NULL,
	[PlayableContentId] [int] NOT NULL,
 CONSTRAINT [PK_PlayableContentCategories] PRIMARY KEY CLUSTERED 
(
	[CategoryId] ASC,
	[PlayableContentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PlayableContentPlaylists]    Script Date: 6/17/2021 6:23:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PlayableContentPlaylists](
	[PlaylistId] [int] NOT NULL,
	[PlayableContentId] [int] NOT NULL,
 CONSTRAINT [PK_PlayableContentPlaylists] PRIMARY KEY CLUSTERED 
(
	[PlayableContentId] ASC,
	[PlaylistId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PlayableContents]    Script Date: 6/17/2021 6:23:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PlayableContents](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Duration] [time](7) NOT NULL,
	[CreatorName] [nvarchar](max) NULL,
	[ImageUrl] [nvarchar](max) NULL,
	[Url] [nvarchar](max) NULL,
	[PlayableContentTypeId] [int] NOT NULL,
 CONSTRAINT [PK_PlayableContents] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PlayableContentTypes]    Script Date: 6/17/2021 6:23:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PlayableContentTypes](
	[Type] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
 CONSTRAINT [PK_PlayableContentTypes] PRIMARY KEY CLUSTERED 
(
	[Type] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Playlists]    Script Date: 6/17/2021 6:23:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Playlists](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](150) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Playlists] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Problematics]    Script Date: 6/17/2021 6:23:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Problematics](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Problematics] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PsychologistProblematics]    Script Date: 6/17/2021 6:23:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PsychologistProblematics](
	[PsychologistId] [int] NOT NULL,
	[ProblematicId] [int] NOT NULL,
 CONSTRAINT [PK_PsychologistProblematics] PRIMARY KEY CLUSTERED 
(
	[PsychologistId] ASC,
	[ProblematicId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Psychologists]    Script Date: 6/17/2021 6:23:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Psychologists](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[ConsultationMode] [nvarchar](max) NOT NULL,
	[Direction] [nvarchar](max) NOT NULL,
	[CreationDate] [datetime2](7) NOT NULL,
	[Fee] [int] NOT NULL,
 CONSTRAINT [PK_Psychologists] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sessions]    Script Date: 6/17/2021 6:23:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sessions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Token] [uniqueidentifier] NOT NULL,
	[AdministratorId] [int] NULL,
 CONSTRAINT [PK_Sessions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210411035719_FirstMigration', N'3.1.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210420191838_CategoryPlaylistIntermediateTable', N'3.1.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210423215055_AudioContentCategory_AudioContentPlaylist_IntermediateTables', N'3.1.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210423222356_Psychologist', N'3.1.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210424010153_Problematics', N'3.1.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210424152749_ProblematicsNameRequired', N'3.1.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210424155604_PsychologistRequiredAttributes', N'3.1.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210424182144_AudioContentNameRequired', N'3.1.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210424190505_PsychologistProblematics_IntermediateTable', N'3.1.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210501125911_Administrator', N'3.1.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210502022549_Consultations_Pacients', N'3.1.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210502022941_Sessions', N'3.1.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210502211057_Agendas', N'3.1.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210503234059_PlaylistRequiredAttributes', N'3.1.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210504013609_Administrators', N'3.1.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210504014224_SeedData', N'3.1.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210506165935_CascadeActions', N'3.1.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210531032213_PlayableContents', N'3.1.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210531194859_Discriminator_Fix', N'3.1.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210601203915_PlayableContentCategories_PlayableContentPlaylists_Changing_Names', N'3.1.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210607225525_Psychologist_Fee', N'3.1.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210609034831_Pacient_Bonus', N'3.1.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210612223709_PlayableContentType', N'3.1.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210617211419_Changing_Category_Name', N'3.1.8')
GO
SET IDENTITY_INSERT [dbo].[Administrators] ON 

INSERT [dbo].[Administrators] ([Id], [Name], [Email], [Password]) VALUES (1, N'SuperAdmin', N'admin@gmail.com', N'1234')
SET IDENTITY_INSERT [dbo].[Administrators] OFF
GO
SET IDENTITY_INSERT [dbo].[Categories] ON 

INSERT [dbo].[Categories] ([Id], [Name]) VALUES (1, N'Dormir')
INSERT [dbo].[Categories] ([Id], [Name]) VALUES (2, N'Meditar')
INSERT [dbo].[Categories] ([Id], [Name]) VALUES (3, N'Musica')
INSERT [dbo].[Categories] ([Id], [Name]) VALUES (4, N'Cuerpo')
SET IDENTITY_INSERT [dbo].[Categories] OFF
GO
SET IDENTITY_INSERT [dbo].[PlayableContentTypes] ON 

INSERT [dbo].[PlayableContentTypes] ([Type], [Name]) VALUES (1, N'Audio')
INSERT [dbo].[PlayableContentTypes] ([Type], [Name]) VALUES (2, N'Video')
SET IDENTITY_INSERT [dbo].[PlayableContentTypes] OFF
GO
SET IDENTITY_INSERT [dbo].[Problematics] ON 

INSERT [dbo].[Problematics] ([Id], [Name]) VALUES (1, N'Depresión')
INSERT [dbo].[Problematics] ([Id], [Name]) VALUES (2, N'Estrés')
INSERT [dbo].[Problematics] ([Id], [Name]) VALUES (3, N'Ansiedad')
INSERT [dbo].[Problematics] ([Id], [Name]) VALUES (4, N'Autoestima')
INSERT [dbo].[Problematics] ([Id], [Name]) VALUES (5, N'Enojo')
INSERT [dbo].[Problematics] ([Id], [Name]) VALUES (6, N'Relaciones')
INSERT [dbo].[Problematics] ([Id], [Name]) VALUES (7, N'Duelo')
INSERT [dbo].[Problematics] ([Id], [Name]) VALUES (8, N'Otros')
SET IDENTITY_INSERT [dbo].[Problematics] OFF
GO
/****** Object:  Index [IX_Agendas_PsychologistId]    Script Date: 6/17/2021 6:23:35 PM ******/
CREATE NONCLUSTERED INDEX [IX_Agendas_PsychologistId] ON [dbo].[Agendas]
(
	[PsychologistId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_CategoryPlaylists_PlaylistId]    Script Date: 6/17/2021 6:23:35 PM ******/
CREATE NONCLUSTERED INDEX [IX_CategoryPlaylists_PlaylistId] ON [dbo].[CategoryPlaylists]
(
	[PlaylistId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Consultations_PacientId]    Script Date: 6/17/2021 6:23:35 PM ******/
CREATE NONCLUSTERED INDEX [IX_Consultations_PacientId] ON [dbo].[Consultations]
(
	[PacientId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Consultations_PsychologistId]    Script Date: 6/17/2021 6:23:35 PM ******/
CREATE NONCLUSTERED INDEX [IX_Consultations_PsychologistId] ON [dbo].[Consultations]
(
	[PsychologistId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_PlayableContentCategories_PlayableContentId]    Script Date: 6/17/2021 6:23:35 PM ******/
CREATE NONCLUSTERED INDEX [IX_PlayableContentCategories_PlayableContentId] ON [dbo].[PlayableContentCategories]
(
	[PlayableContentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_PlayableContentPlaylists_PlaylistId]    Script Date: 6/17/2021 6:23:35 PM ******/
CREATE NONCLUSTERED INDEX [IX_PlayableContentPlaylists_PlaylistId] ON [dbo].[PlayableContentPlaylists]
(
	[PlaylistId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_PlayableContents_PlayableContentTypeId]    Script Date: 6/17/2021 6:23:35 PM ******/
CREATE NONCLUSTERED INDEX [IX_PlayableContents_PlayableContentTypeId] ON [dbo].[PlayableContents]
(
	[PlayableContentTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_PsychologistProblematics_ProblematicId]    Script Date: 6/17/2021 6:23:35 PM ******/
CREATE NONCLUSTERED INDEX [IX_PsychologistProblematics_ProblematicId] ON [dbo].[PsychologistProblematics]
(
	[ProblematicId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Sessions_AdministratorId]    Script Date: 6/17/2021 6:23:35 PM ******/
CREATE NONCLUSTERED INDEX [IX_Sessions_AdministratorId] ON [dbo].[Sessions]
(
	[AdministratorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Consultations] ADD  DEFAULT ((0.0)) FOR [Cost]
GO
ALTER TABLE [dbo].[Consultations] ADD  DEFAULT ((0.0)) FOR [Duration]
GO
ALTER TABLE [dbo].[Pacients] ADD  DEFAULT ((0.0)) FOR [BonusAmount]
GO
ALTER TABLE [dbo].[Pacients] ADD  DEFAULT (CONVERT([bit],(0))) FOR [BonusApproved]
GO
ALTER TABLE [dbo].[Pacients] ADD  DEFAULT ((0)) FOR [ConsultationsQuantity]
GO
ALTER TABLE [dbo].[Pacients] ADD  DEFAULT (CONVERT([bit],(0))) FOR [GeneratedBonus]
GO
ALTER TABLE [dbo].[PlayableContentCategories] ADD  DEFAULT ((0)) FOR [PlayableContentId]
GO
ALTER TABLE [dbo].[PlayableContentPlaylists] ADD  DEFAULT ((0)) FOR [PlayableContentId]
GO
ALTER TABLE [dbo].[PlayableContents] ADD  DEFAULT ((0)) FOR [PlayableContentTypeId]
GO
ALTER TABLE [dbo].[Playlists] ADD  DEFAULT (N'') FOR [Description]
GO
ALTER TABLE [dbo].[Playlists] ADD  DEFAULT (N'') FOR [Name]
GO
ALTER TABLE [dbo].[Psychologists] ADD  DEFAULT ((0)) FOR [Fee]
GO
ALTER TABLE [dbo].[Agendas]  WITH CHECK ADD  CONSTRAINT [FK_Agendas_Psychologists_PsychologistId] FOREIGN KEY([PsychologistId])
REFERENCES [dbo].[Psychologists] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Agendas] CHECK CONSTRAINT [FK_Agendas_Psychologists_PsychologistId]
GO
ALTER TABLE [dbo].[CategoryPlaylists]  WITH CHECK ADD  CONSTRAINT [FK_CategoryPlaylists_Categories_CategoryId] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Categories] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CategoryPlaylists] CHECK CONSTRAINT [FK_CategoryPlaylists_Categories_CategoryId]
GO
ALTER TABLE [dbo].[CategoryPlaylists]  WITH CHECK ADD  CONSTRAINT [FK_CategoryPlaylists_Playlists_PlaylistId] FOREIGN KEY([PlaylistId])
REFERENCES [dbo].[Playlists] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CategoryPlaylists] CHECK CONSTRAINT [FK_CategoryPlaylists_Playlists_PlaylistId]
GO
ALTER TABLE [dbo].[Consultations]  WITH CHECK ADD  CONSTRAINT [FK_Consultations_Pacients_PacientId] FOREIGN KEY([PacientId])
REFERENCES [dbo].[Pacients] ([Id])
GO
ALTER TABLE [dbo].[Consultations] CHECK CONSTRAINT [FK_Consultations_Pacients_PacientId]
GO
ALTER TABLE [dbo].[Consultations]  WITH CHECK ADD  CONSTRAINT [FK_Consultations_Psychologists_PsychologistId] FOREIGN KEY([PsychologistId])
REFERENCES [dbo].[Psychologists] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Consultations] CHECK CONSTRAINT [FK_Consultations_Psychologists_PsychologistId]
GO
ALTER TABLE [dbo].[PlayableContentCategories]  WITH CHECK ADD  CONSTRAINT [FK_PlayableContentCategories_Categories_CategoryId] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Categories] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PlayableContentCategories] CHECK CONSTRAINT [FK_PlayableContentCategories_Categories_CategoryId]
GO
ALTER TABLE [dbo].[PlayableContentCategories]  WITH CHECK ADD  CONSTRAINT [FK_PlayableContentCategories_PlayableContents_PlayableContentId] FOREIGN KEY([PlayableContentId])
REFERENCES [dbo].[PlayableContents] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PlayableContentCategories] CHECK CONSTRAINT [FK_PlayableContentCategories_PlayableContents_PlayableContentId]
GO
ALTER TABLE [dbo].[PlayableContentPlaylists]  WITH CHECK ADD  CONSTRAINT [FK_PlayableContentPlaylists_PlayableContents_PlayableContentId] FOREIGN KEY([PlayableContentId])
REFERENCES [dbo].[PlayableContents] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PlayableContentPlaylists] CHECK CONSTRAINT [FK_PlayableContentPlaylists_PlayableContents_PlayableContentId]
GO
ALTER TABLE [dbo].[PlayableContentPlaylists]  WITH CHECK ADD  CONSTRAINT [FK_PlayableContentPlaylists_Playlists_PlaylistId] FOREIGN KEY([PlaylistId])
REFERENCES [dbo].[Playlists] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PlayableContentPlaylists] CHECK CONSTRAINT [FK_PlayableContentPlaylists_Playlists_PlaylistId]
GO
ALTER TABLE [dbo].[PlayableContents]  WITH CHECK ADD  CONSTRAINT [FK_PlayableContents_PlayableContentTypes_PlayableContentTypeId] FOREIGN KEY([PlayableContentTypeId])
REFERENCES [dbo].[PlayableContentTypes] ([Type])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PlayableContents] CHECK CONSTRAINT [FK_PlayableContents_PlayableContentTypes_PlayableContentTypeId]
GO
ALTER TABLE [dbo].[PsychologistProblematics]  WITH CHECK ADD  CONSTRAINT [FK_PsychologistProblematics_Problematics_ProblematicId] FOREIGN KEY([ProblematicId])
REFERENCES [dbo].[Problematics] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PsychologistProblematics] CHECK CONSTRAINT [FK_PsychologistProblematics_Problematics_ProblematicId]
GO
ALTER TABLE [dbo].[PsychologistProblematics]  WITH CHECK ADD  CONSTRAINT [FK_PsychologistProblematics_Psychologists_PsychologistId] FOREIGN KEY([PsychologistId])
REFERENCES [dbo].[Psychologists] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PsychologistProblematics] CHECK CONSTRAINT [FK_PsychologistProblematics_Psychologists_PsychologistId]
GO
ALTER TABLE [dbo].[Sessions]  WITH CHECK ADD  CONSTRAINT [FK_Sessions_Administrators_AdministratorId] FOREIGN KEY([AdministratorId])
REFERENCES [dbo].[Administrators] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Sessions] CHECK CONSTRAINT [FK_Sessions_Administrators_AdministratorId]
GO
USE [master]
GO
ALTER DATABASE [BetterCalmDB] SET  READ_WRITE 
GO
