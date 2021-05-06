USE [BetterCalmDB]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 6/5/2021 18:07:48 ******/
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
/****** Object:  Table [dbo].[Administrators]    Script Date: 6/5/2021 18:07:48 ******/
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
/****** Object:  Table [dbo].[Agendas]    Script Date: 6/5/2021 18:07:48 ******/
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
/****** Object:  Table [dbo].[AudioContentCategories]    Script Date: 6/5/2021 18:07:49 ******/
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
/****** Object:  Table [dbo].[AudioContentPlaylists]    Script Date: 6/5/2021 18:07:49 ******/
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
/****** Object:  Table [dbo].[AudioContents]    Script Date: 6/5/2021 18:07:49 ******/
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
/****** Object:  Table [dbo].[Categories]    Script Date: 6/5/2021 18:07:49 ******/
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
/****** Object:  Table [dbo].[CategoryPlaylists]    Script Date: 6/5/2021 18:07:49 ******/
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
/****** Object:  Table [dbo].[Consultations]    Script Date: 6/5/2021 18:07:49 ******/
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
/****** Object:  Table [dbo].[Pacients]    Script Date: 6/5/2021 18:07:49 ******/
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
/****** Object:  Table [dbo].[Playlists]    Script Date: 6/5/2021 18:07:49 ******/
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
/****** Object:  Table [dbo].[Problematics]    Script Date: 6/5/2021 18:07:49 ******/
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
/****** Object:  Table [dbo].[PsychologistProblematics]    Script Date: 6/5/2021 18:07:49 ******/
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
/****** Object:  Table [dbo].[Psychologists]    Script Date: 6/5/2021 18:07:49 ******/
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
/****** Object:  Table [dbo].[Sessions]    Script Date: 6/5/2021 18:07:49 ******/
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
