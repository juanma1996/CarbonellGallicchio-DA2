USE [master]
GO
/****** Object:  Database [BetterCalmDB]    Script Date: 6/5/2021 18:38:50 ******/
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
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 6/5/2021 18:38:50 ******/
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
/****** Object:  Table [dbo].[Administrators]    Script Date: 6/5/2021 18:38:50 ******/
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
/****** Object:  Table [dbo].[Agendas]    Script Date: 6/5/2021 18:38:50 ******/
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
/****** Object:  Table [dbo].[AudioContentCategories]    Script Date: 6/5/2021 18:38:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AudioContentCategories](
	[CategoryId] [int] NOT NULL,
	[AudioContentId] [int] NOT NULL,
 CONSTRAINT [PK_AudioContentCategories] PRIMARY KEY CLUSTERED 
(
	[CategoryId] ASC,
	[AudioContentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AudioContentPlaylists]    Script Date: 6/5/2021 18:38:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AudioContentPlaylists](
	[PlaylistId] [int] NOT NULL,
	[AudioContentId] [int] NOT NULL,
 CONSTRAINT [PK_AudioContentPlaylists] PRIMARY KEY CLUSTERED 
(
	[AudioContentId] ASC,
	[PlaylistId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AudioContents]    Script Date: 6/5/2021 18:38:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AudioContents](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Duration] [time](7) NOT NULL,
	[CreatorName] [nvarchar](max) NULL,
	[ImageUrl] [nvarchar](max) NULL,
	[AudioUrl] [nvarchar](max) NULL,
 CONSTRAINT [PK_AudioContents] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 6/5/2021 18:38:50 ******/
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
/****** Object:  Table [dbo].[CategoryPlaylists]    Script Date: 6/5/2021 18:38:50 ******/
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
/****** Object:  Table [dbo].[Consultations]    Script Date: 6/5/2021 18:38:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Consultations](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProblematicId] [int] NOT NULL,
	[PacientId] [int] NULL,
	[PsychologistId] [int] NULL,
 CONSTRAINT [PK_Consultations] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pacients]    Script Date: 6/5/2021 18:38:50 ******/
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
 CONSTRAINT [PK_Pacients] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Playlists]    Script Date: 6/5/2021 18:38:50 ******/
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
/****** Object:  Table [dbo].[Problematics]    Script Date: 6/5/2021 18:38:50 ******/
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
/****** Object:  Table [dbo].[PsychologistProblematics]    Script Date: 6/5/2021 18:38:50 ******/
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
/****** Object:  Table [dbo].[Psychologists]    Script Date: 6/5/2021 18:38:50 ******/
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
 CONSTRAINT [PK_Psychologists] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sessions]    Script Date: 6/5/2021 18:38:50 ******/
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
GO
SET IDENTITY_INSERT [dbo].[Administrators] ON 

INSERT [dbo].[Administrators] ([Id], [Name], [Email], [Password]) VALUES (1, N'SuperAdmin', N'admin@gmail.com', N'1234')
INSERT [dbo].[Administrators] ([Id], [Name], [Email], [Password]) VALUES (2, N'Juan', N'juan@gmail.com', N'1234')
INSERT [dbo].[Administrators] ([Id], [Name], [Email], [Password]) VALUES (3, N'Fede', N'fede@gmail.com', N'dsfdsfdsfdsf')
INSERT [dbo].[Administrators] ([Id], [Name], [Email], [Password]) VALUES (4, N'Jaimito', N'jaime@hotmail.com', N'dsfdsfdsfdsf')
INSERT [dbo].[Administrators] ([Id], [Name], [Email], [Password]) VALUES (5, N'Cristian', N'rodriguez@hotmail.com', N'32424324324')
INSERT [dbo].[Administrators] ([Id], [Name], [Email], [Password]) VALUES (6, N'Marcos', N'castro@hotmail.com', N'sdfdf')
SET IDENTITY_INSERT [dbo].[Administrators] OFF
GO
SET IDENTITY_INSERT [dbo].[Agendas] ON 

INSERT [dbo].[Agendas] ([Id], [PsychologistId], [Date], [Count], [IsAvaible]) VALUES (1, 1, CAST(N'2021-05-06T18:27:57.2059936' AS DateTime2), 5, 0)
INSERT [dbo].[Agendas] ([Id], [PsychologistId], [Date], [Count], [IsAvaible]) VALUES (2, 8, CAST(N'2021-05-06T18:27:57.2059936' AS DateTime2), 0, 1)
INSERT [dbo].[Agendas] ([Id], [PsychologistId], [Date], [Count], [IsAvaible]) VALUES (3, 4, CAST(N'2021-05-06T18:28:28.5215759' AS DateTime2), 1, 1)
INSERT [dbo].[Agendas] ([Id], [PsychologistId], [Date], [Count], [IsAvaible]) VALUES (4, 5, CAST(N'2021-05-06T18:28:28.5215759' AS DateTime2), 0, 1)
INSERT [dbo].[Agendas] ([Id], [PsychologistId], [Date], [Count], [IsAvaible]) VALUES (5, 6, CAST(N'2021-05-06T18:28:28.5215759' AS DateTime2), 0, 1)
INSERT [dbo].[Agendas] ([Id], [PsychologistId], [Date], [Count], [IsAvaible]) VALUES (6, 2, CAST(N'2021-05-06T18:28:37.2799078' AS DateTime2), 3, 1)
INSERT [dbo].[Agendas] ([Id], [PsychologistId], [Date], [Count], [IsAvaible]) VALUES (7, 3, CAST(N'2021-05-06T18:28:37.2799078' AS DateTime2), 0, 1)
INSERT [dbo].[Agendas] ([Id], [PsychologistId], [Date], [Count], [IsAvaible]) VALUES (8, 7, CAST(N'2021-05-06T18:28:37.2799078' AS DateTime2), 0, 1)
SET IDENTITY_INSERT [dbo].[Agendas] OFF
GO
INSERT [dbo].[AudioContentCategories] ([CategoryId], [AudioContentId]) VALUES (1, 1)
INSERT [dbo].[AudioContentCategories] ([CategoryId], [AudioContentId]) VALUES (3, 2)
INSERT [dbo].[AudioContentCategories] ([CategoryId], [AudioContentId]) VALUES (4, 3)
INSERT [dbo].[AudioContentCategories] ([CategoryId], [AudioContentId]) VALUES (4, 4)
INSERT [dbo].[AudioContentCategories] ([CategoryId], [AudioContentId]) VALUES (4, 5)
INSERT [dbo].[AudioContentCategories] ([CategoryId], [AudioContentId]) VALUES (4, 6)
INSERT [dbo].[AudioContentCategories] ([CategoryId], [AudioContentId]) VALUES (4, 7)
INSERT [dbo].[AudioContentCategories] ([CategoryId], [AudioContentId]) VALUES (4, 8)
INSERT [dbo].[AudioContentCategories] ([CategoryId], [AudioContentId]) VALUES (4, 9)
INSERT [dbo].[AudioContentCategories] ([CategoryId], [AudioContentId]) VALUES (4, 10)
GO
INSERT [dbo].[AudioContentPlaylists] ([PlaylistId], [AudioContentId]) VALUES (1, 1)
INSERT [dbo].[AudioContentPlaylists] ([PlaylistId], [AudioContentId]) VALUES (2, 2)
INSERT [dbo].[AudioContentPlaylists] ([PlaylistId], [AudioContentId]) VALUES (3, 3)
INSERT [dbo].[AudioContentPlaylists] ([PlaylistId], [AudioContentId]) VALUES (4, 4)
INSERT [dbo].[AudioContentPlaylists] ([PlaylistId], [AudioContentId]) VALUES (4, 5)
INSERT [dbo].[AudioContentPlaylists] ([PlaylistId], [AudioContentId]) VALUES (4, 6)
INSERT [dbo].[AudioContentPlaylists] ([PlaylistId], [AudioContentId]) VALUES (4, 7)
INSERT [dbo].[AudioContentPlaylists] ([PlaylistId], [AudioContentId]) VALUES (4, 8)
INSERT [dbo].[AudioContentPlaylists] ([PlaylistId], [AudioContentId]) VALUES (5, 9)
INSERT [dbo].[AudioContentPlaylists] ([PlaylistId], [AudioContentId]) VALUES (5, 10)
GO
SET IDENTITY_INSERT [dbo].[AudioContents] ON 

INSERT [dbo].[AudioContents] ([Id], [Name], [Duration], [CreatorName], [ImageUrl], [AudioUrl]) VALUES (1, N'One song', CAST(N'00:00:00' AS Time), N'Juan', N'www.songs.com/onesong', N'www.audios.com/oneaudio')
INSERT [dbo].[AudioContents] ([Id], [Name], [Duration], [CreatorName], [ImageUrl], [AudioUrl]) VALUES (2, N'Other song', CAST(N'00:00:00' AS Time), N'Federico', N'www.songs.com/onesong', N'www.audios.com/oneaudio')
INSERT [dbo].[AudioContents] ([Id], [Name], [Duration], [CreatorName], [ImageUrl], [AudioUrl]) VALUES (3, N'Runaway', CAST(N'00:00:00' AS Time), N'Federico', N'www.songs.com/onesong', N'www.audios.com/oneaudio')
INSERT [dbo].[AudioContents] ([Id], [Name], [Duration], [CreatorName], [ImageUrl], [AudioUrl]) VALUES (4, N'La manteca', CAST(N'00:00:00' AS Time), N'Lit Killah', N'https://www.youtube.com/watch?v=5qDgZNQ7XcU', N'https://www.youtube.com/watch?v=5qDgZNQ7XcU')
INSERT [dbo].[AudioContents] ([Id], [Name], [Duration], [CreatorName], [ImageUrl], [AudioUrl]) VALUES (5, N'BizRap session', CAST(N'00:00:00' AS Time), N'Lit Killah', N'https://www.youtube.com/watch?v=5qDgZNQ7XcU', N'https://www.youtube.com/watch?v=5qDgZNQ7XcU')
INSERT [dbo].[AudioContents] ([Id], [Name], [Duration], [CreatorName], [ImageUrl], [AudioUrl]) VALUES (6, N'Loca', CAST(N'00:00:00' AS Time), N'Duki', N'https://www.youtube.com/watch?v=5qDgZNQ7XcU', N'https://www.youtube.com/watch?v=5qDgZNQ7XcU')
INSERT [dbo].[AudioContents] ([Id], [Name], [Duration], [CreatorName], [ImageUrl], [AudioUrl]) VALUES (7, N'Wacha', CAST(N'00:00:00' AS Time), N'Khea y Duki', N'https://www.youtube.com/watch?v=5qDgZNQ7XcU', N'https://www.youtube.com/watch?v=5qDgZNQ7XcU')
INSERT [dbo].[AudioContents] ([Id], [Name], [Duration], [CreatorName], [ImageUrl], [AudioUrl]) VALUES (8, N'Rockstar', CAST(N'00:00:00' AS Time), N'Khea y Duki', N'https://www.youtube.com/watch?v=5qDgZNQ7XcU', N'https://www.youtube.com/watch?v=5qDgZNQ7XcU')
INSERT [dbo].[AudioContents] ([Id], [Name], [Duration], [CreatorName], [ImageUrl], [AudioUrl]) VALUES (9, N'El cielo se quedo sin estrellas', CAST(N'00:00:00' AS Time), N'18 kilates', N'https://www.youtube.com/watch?v=5qDgZNQ7XcU', N'https://www.youtube.com/watch?v=5qDgZNQ7XcU')
INSERT [dbo].[AudioContents] ([Id], [Name], [Duration], [CreatorName], [ImageUrl], [AudioUrl]) VALUES (10, N'Amor de chat', CAST(N'00:00:00' AS Time), N'18 kilates', N'https://www.youtube.com/watch?v=5qDgZNQ7XcU', N'https://www.youtube.com/watch?v=5qDgZNQ7XcU')
SET IDENTITY_INSERT [dbo].[AudioContents] OFF
GO
SET IDENTITY_INSERT [dbo].[Categories] ON 

INSERT [dbo].[Categories] ([Id], [Name]) VALUES (1, N'Dormir')
INSERT [dbo].[Categories] ([Id], [Name]) VALUES (2, N'Meditar')
INSERT [dbo].[Categories] ([Id], [Name]) VALUES (3, N'Música')
INSERT [dbo].[Categories] ([Id], [Name]) VALUES (4, N'Cuerpo')
SET IDENTITY_INSERT [dbo].[Categories] OFF
GO
INSERT [dbo].[CategoryPlaylists] ([CategoryId], [PlaylistId]) VALUES (1, 1)
INSERT [dbo].[CategoryPlaylists] ([CategoryId], [PlaylistId]) VALUES (3, 2)
INSERT [dbo].[CategoryPlaylists] ([CategoryId], [PlaylistId]) VALUES (4, 3)
INSERT [dbo].[CategoryPlaylists] ([CategoryId], [PlaylistId]) VALUES (4, 4)
INSERT [dbo].[CategoryPlaylists] ([CategoryId], [PlaylistId]) VALUES (4, 5)
GO
SET IDENTITY_INSERT [dbo].[Consultations] ON 

INSERT [dbo].[Consultations] ([Id], [ProblematicId], [PacientId], [PsychologistId]) VALUES (1, 1, 1, 1)
INSERT [dbo].[Consultations] ([Id], [ProblematicId], [PacientId], [PsychologistId]) VALUES (2, 1, 2, 1)
INSERT [dbo].[Consultations] ([Id], [ProblematicId], [PacientId], [PsychologistId]) VALUES (3, 7, 3, 4)
INSERT [dbo].[Consultations] ([Id], [ProblematicId], [PacientId], [PsychologistId]) VALUES (4, 8, 4, 1)
INSERT [dbo].[Consultations] ([Id], [ProblematicId], [PacientId], [PsychologistId]) VALUES (5, 3, 5, 1)
INSERT [dbo].[Consultations] ([Id], [ProblematicId], [PacientId], [PsychologistId]) VALUES (6, 4, 6, 2)
INSERT [dbo].[Consultations] ([Id], [ProblematicId], [PacientId], [PsychologistId]) VALUES (7, 8, 7, 1)
INSERT [dbo].[Consultations] ([Id], [ProblematicId], [PacientId], [PsychologistId]) VALUES (8, 5, 8, 2)
INSERT [dbo].[Consultations] ([Id], [ProblematicId], [PacientId], [PsychologistId]) VALUES (9, 8, 9, 2)
SET IDENTITY_INSERT [dbo].[Consultations] OFF
GO
SET IDENTITY_INSERT [dbo].[Pacients] ON 

INSERT [dbo].[Pacients] ([Id], [Name], [Surname], [BirthDate], [Email], [Cellphone]) VALUES (1, N'Federico', N'Carbonell', CAST(N'1996-01-01T00:00:00.0000000' AS DateTime2), N'fede@gmail.com', N'093732134')
INSERT [dbo].[Pacients] ([Id], [Name], [Surname], [BirthDate], [Email], [Cellphone]) VALUES (2, N'Juan', N'Gallicchio', CAST(N'1996-01-01T00:00:00.0000000' AS DateTime2), N'juan@gmail.com', N'093732134')
INSERT [dbo].[Pacients] ([Id], [Name], [Surname], [BirthDate], [Email], [Cellphone]) VALUES (3, N'Esteban', N'Gallicchio', CAST(N'1996-01-01T00:00:00.0000000' AS DateTime2), N'esteban@gmail.com', N'093732134')
INSERT [dbo].[Pacients] ([Id], [Name], [Surname], [BirthDate], [Email], [Cellphone]) VALUES (4, N'Quique', N'Gallicchio', CAST(N'1996-01-01T00:00:00.0000000' AS DateTime2), N'esteban@gmail.com', N'093732134')
INSERT [dbo].[Pacients] ([Id], [Name], [Surname], [BirthDate], [Email], [Cellphone]) VALUES (5, N'Quique', N'Gallicchio', CAST(N'1996-01-01T00:00:00.0000000' AS DateTime2), N'esteban@gmail.com', N'093732134')
INSERT [dbo].[Pacients] ([Id], [Name], [Surname], [BirthDate], [Email], [Cellphone]) VALUES (6, N'Quique', N'Gallicchio', CAST(N'1996-01-01T00:00:00.0000000' AS DateTime2), N'esteban@gmail.com', N'093732134')
INSERT [dbo].[Pacients] ([Id], [Name], [Surname], [BirthDate], [Email], [Cellphone]) VALUES (7, N'Elena', N'Antelo', CAST(N'1996-01-01T00:00:00.0000000' AS DateTime2), N'elena@gmail.com', N'093732134')
INSERT [dbo].[Pacients] ([Id], [Name], [Surname], [BirthDate], [Email], [Cellphone]) VALUES (8, N'Carolina', N'Otero', CAST(N'1996-01-01T00:00:00.0000000' AS DateTime2), N'caro@gmail.com', N'093732134')
INSERT [dbo].[Pacients] ([Id], [Name], [Surname], [BirthDate], [Email], [Cellphone]) VALUES (9, N'Candela', N'Eliceiry', CAST(N'1996-01-01T00:00:00.0000000' AS DateTime2), N'soycande@gmail.com', N'093732134')
SET IDENTITY_INSERT [dbo].[Pacients] OFF
GO
SET IDENTITY_INSERT [dbo].[Playlists] ON 

INSERT [dbo].[Playlists] ([Id], [Description], [Name]) VALUES (1, N'This is a new playlist valid', N'New playlist')
INSERT [dbo].[Playlists] ([Id], [Description], [Name]) VALUES (2, N'This is my playlist', N'My playlist')
INSERT [dbo].[Playlists] ([Id], [Description], [Name]) VALUES (3, N'This is my playlist', N'Reggae')
INSERT [dbo].[Playlists] ([Id], [Description], [Name]) VALUES (4, N'This is my playlist', N'Trap')
INSERT [dbo].[Playlists] ([Id], [Description], [Name]) VALUES (5, N'This is my playlist', N'Cumbia vieja')
SET IDENTITY_INSERT [dbo].[Playlists] OFF
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
INSERT [dbo].[PsychologistProblematics] ([PsychologistId], [ProblematicId]) VALUES (1, 1)
INSERT [dbo].[PsychologistProblematics] ([PsychologistId], [ProblematicId]) VALUES (8, 1)
INSERT [dbo].[PsychologistProblematics] ([PsychologistId], [ProblematicId]) VALUES (1, 2)
INSERT [dbo].[PsychologistProblematics] ([PsychologistId], [ProblematicId]) VALUES (8, 2)
INSERT [dbo].[PsychologistProblematics] ([PsychologistId], [ProblematicId]) VALUES (1, 3)
INSERT [dbo].[PsychologistProblematics] ([PsychologistId], [ProblematicId]) VALUES (2, 3)
INSERT [dbo].[PsychologistProblematics] ([PsychologistId], [ProblematicId]) VALUES (8, 3)
INSERT [dbo].[PsychologistProblematics] ([PsychologistId], [ProblematicId]) VALUES (2, 4)
INSERT [dbo].[PsychologistProblematics] ([PsychologistId], [ProblematicId]) VALUES (3, 4)
INSERT [dbo].[PsychologistProblematics] ([PsychologistId], [ProblematicId]) VALUES (7, 4)
INSERT [dbo].[PsychologistProblematics] ([PsychologistId], [ProblematicId]) VALUES (2, 5)
INSERT [dbo].[PsychologistProblematics] ([PsychologistId], [ProblematicId]) VALUES (3, 5)
INSERT [dbo].[PsychologistProblematics] ([PsychologistId], [ProblematicId]) VALUES (4, 5)
INSERT [dbo].[PsychologistProblematics] ([PsychologistId], [ProblematicId]) VALUES (5, 5)
INSERT [dbo].[PsychologistProblematics] ([PsychologistId], [ProblematicId]) VALUES (6, 5)
INSERT [dbo].[PsychologistProblematics] ([PsychologistId], [ProblematicId]) VALUES (7, 5)
INSERT [dbo].[PsychologistProblematics] ([PsychologistId], [ProblematicId]) VALUES (3, 6)
INSERT [dbo].[PsychologistProblematics] ([PsychologistId], [ProblematicId]) VALUES (4, 6)
INSERT [dbo].[PsychologistProblematics] ([PsychologistId], [ProblematicId]) VALUES (7, 6)
INSERT [dbo].[PsychologistProblematics] ([PsychologistId], [ProblematicId]) VALUES (4, 7)
INSERT [dbo].[PsychologistProblematics] ([PsychologistId], [ProblematicId]) VALUES (5, 7)
INSERT [dbo].[PsychologistProblematics] ([PsychologistId], [ProblematicId]) VALUES (6, 7)
INSERT [dbo].[PsychologistProblematics] ([PsychologistId], [ProblematicId]) VALUES (5, 8)
INSERT [dbo].[PsychologistProblematics] ([PsychologistId], [ProblematicId]) VALUES (6, 8)
GO
SET IDENTITY_INSERT [dbo].[Psychologists] ON 

INSERT [dbo].[Psychologists] ([Id], [Name], [ConsultationMode], [Direction], [CreationDate]) VALUES (1, N'Roberto', N'Virtual', N'18 de Julio 2034', CAST(N'2021-05-06T18:24:46.2388692' AS DateTime2))
INSERT [dbo].[Psychologists] ([Id], [Name], [ConsultationMode], [Direction], [CreationDate]) VALUES (2, N'Martin', N'Virtual', N'', CAST(N'2021-05-06T18:25:01.3981121' AS DateTime2))
INSERT [dbo].[Psychologists] ([Id], [Name], [ConsultationMode], [Direction], [CreationDate]) VALUES (3, N'Javier', N'Virtual', N'', CAST(N'2021-05-06T18:25:14.7828008' AS DateTime2))
INSERT [dbo].[Psychologists] ([Id], [Name], [ConsultationMode], [Direction], [CreationDate]) VALUES (4, N'Renzo', N'Presencial', N'Antonio Pena 465', CAST(N'2021-05-06T18:25:50.7020928' AS DateTime2))
INSERT [dbo].[Psychologists] ([Id], [Name], [ConsultationMode], [Direction], [CreationDate]) VALUES (5, N'Agustina', N'Presencial', N'Mercedes 4576', CAST(N'2021-05-06T18:27:18.0146560' AS DateTime2))
INSERT [dbo].[Psychologists] ([Id], [Name], [ConsultationMode], [Direction], [CreationDate]) VALUES (6, N'Cristian', N'Presencial', N'Santa monica 4576', CAST(N'2021-05-06T18:27:32.9778482' AS DateTime2))
INSERT [dbo].[Psychologists] ([Id], [Name], [ConsultationMode], [Direction], [CreationDate]) VALUES (7, N'Javier Presencial', N'Presencial', N'18 de Julio 2034', CAST(N'2021-05-06T18:27:41.4227529' AS DateTime2))
INSERT [dbo].[Psychologists] ([Id], [Name], [ConsultationMode], [Direction], [CreationDate]) VALUES (8, N'Javier Virtual', N'Virtual', N'18 de Julio 2034', CAST(N'2021-05-06T18:27:44.0260974' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Psychologists] OFF
GO
SET IDENTITY_INSERT [dbo].[Sessions] ON 

INSERT [dbo].[Sessions] ([Id], [Token], [AdministratorId]) VALUES (1, N'df6dea4d-1a92-41f2-9e3e-364f3672a9b9', 1)
SET IDENTITY_INSERT [dbo].[Sessions] OFF
GO
/****** Object:  Index [IX_Agendas_PsychologistId]    Script Date: 6/5/2021 18:38:51 ******/
CREATE NONCLUSTERED INDEX [IX_Agendas_PsychologistId] ON [dbo].[Agendas]
(
	[PsychologistId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_AudioContentCategories_AudioContentId]    Script Date: 6/5/2021 18:38:51 ******/
CREATE NONCLUSTERED INDEX [IX_AudioContentCategories_AudioContentId] ON [dbo].[AudioContentCategories]
(
	[AudioContentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_AudioContentPlaylists_PlaylistId]    Script Date: 6/5/2021 18:38:51 ******/
CREATE NONCLUSTERED INDEX [IX_AudioContentPlaylists_PlaylistId] ON [dbo].[AudioContentPlaylists]
(
	[PlaylistId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_CategoryPlaylists_PlaylistId]    Script Date: 6/5/2021 18:38:51 ******/
CREATE NONCLUSTERED INDEX [IX_CategoryPlaylists_PlaylistId] ON [dbo].[CategoryPlaylists]
(
	[PlaylistId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Consultations_PacientId]    Script Date: 6/5/2021 18:38:51 ******/
CREATE NONCLUSTERED INDEX [IX_Consultations_PacientId] ON [dbo].[Consultations]
(
	[PacientId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Consultations_PsychologistId]    Script Date: 6/5/2021 18:38:51 ******/
CREATE NONCLUSTERED INDEX [IX_Consultations_PsychologistId] ON [dbo].[Consultations]
(
	[PsychologistId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_PsychologistProblematics_ProblematicId]    Script Date: 6/5/2021 18:38:51 ******/
CREATE NONCLUSTERED INDEX [IX_PsychologistProblematics_ProblematicId] ON [dbo].[PsychologistProblematics]
(
	[ProblematicId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Sessions_AdministratorId]    Script Date: 6/5/2021 18:38:51 ******/
CREATE NONCLUSTERED INDEX [IX_Sessions_AdministratorId] ON [dbo].[Sessions]
(
	[AdministratorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Playlists] ADD  DEFAULT (N'') FOR [Description]
GO
ALTER TABLE [dbo].[Playlists] ADD  DEFAULT (N'') FOR [Name]
GO
ALTER TABLE [dbo].[Agendas]  WITH CHECK ADD  CONSTRAINT [FK_Agendas_Psychologists_PsychologistId] FOREIGN KEY([PsychologistId])
REFERENCES [dbo].[Psychologists] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Agendas] CHECK CONSTRAINT [FK_Agendas_Psychologists_PsychologistId]
GO
ALTER TABLE [dbo].[AudioContentCategories]  WITH CHECK ADD  CONSTRAINT [FK_AudioContentCategories_AudioContents_AudioContentId] FOREIGN KEY([AudioContentId])
REFERENCES [dbo].[AudioContents] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AudioContentCategories] CHECK CONSTRAINT [FK_AudioContentCategories_AudioContents_AudioContentId]
GO
ALTER TABLE [dbo].[AudioContentCategories]  WITH CHECK ADD  CONSTRAINT [FK_AudioContentCategories_Categories_CategoryId] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Categories] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AudioContentCategories] CHECK CONSTRAINT [FK_AudioContentCategories_Categories_CategoryId]
GO
ALTER TABLE [dbo].[AudioContentPlaylists]  WITH CHECK ADD  CONSTRAINT [FK_AudioContentPlaylists_AudioContents_AudioContentId] FOREIGN KEY([AudioContentId])
REFERENCES [dbo].[AudioContents] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AudioContentPlaylists] CHECK CONSTRAINT [FK_AudioContentPlaylists_AudioContents_AudioContentId]
GO
ALTER TABLE [dbo].[AudioContentPlaylists]  WITH CHECK ADD  CONSTRAINT [FK_AudioContentPlaylists_Playlists_PlaylistId] FOREIGN KEY([PlaylistId])
REFERENCES [dbo].[Playlists] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AudioContentPlaylists] CHECK CONSTRAINT [FK_AudioContentPlaylists_Playlists_PlaylistId]
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
