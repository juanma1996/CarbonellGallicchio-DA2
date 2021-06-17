USE [BetterCalmDB]
GO
/****** Object:  Table [dbo].[Administrators]    Script Date: 6/17/2021 6:57:52 PM ******/
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
/****** Object:  Table [dbo].[Agendas]    Script Date: 6/17/2021 6:57:52 PM ******/
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
/****** Object:  Table [dbo].[Categories]    Script Date: 6/17/2021 6:57:52 PM ******/
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
/****** Object:  Table [dbo].[CategoryPlaylists]    Script Date: 6/17/2021 6:57:52 PM ******/
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
/****** Object:  Table [dbo].[Consultations]    Script Date: 6/17/2021 6:57:52 PM ******/
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
/****** Object:  Table [dbo].[Pacients]    Script Date: 6/17/2021 6:57:52 PM ******/
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
/****** Object:  Table [dbo].[PlayableContentCategories]    Script Date: 6/17/2021 6:57:52 PM ******/
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
/****** Object:  Table [dbo].[PlayableContentPlaylists]    Script Date: 6/17/2021 6:57:52 PM ******/
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
/****** Object:  Table [dbo].[PlayableContents]    Script Date: 6/17/2021 6:57:52 PM ******/
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
/****** Object:  Table [dbo].[PlayableContentTypes]    Script Date: 6/17/2021 6:57:52 PM ******/
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
/****** Object:  Table [dbo].[Playlists]    Script Date: 6/17/2021 6:57:52 PM ******/
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
/****** Object:  Table [dbo].[Problematics]    Script Date: 6/17/2021 6:57:52 PM ******/
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
/****** Object:  Table [dbo].[PsychologistProblematics]    Script Date: 6/17/2021 6:57:52 PM ******/
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
/****** Object:  Table [dbo].[Psychologists]    Script Date: 6/17/2021 6:57:52 PM ******/
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
/****** Object:  Table [dbo].[Sessions]    Script Date: 6/17/2021 6:57:52 PM ******/
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
SET IDENTITY_INSERT [dbo].[Administrators] ON 

INSERT [dbo].[Administrators] ([Id], [Name], [Email], [Password]) VALUES (1, N'SuperAdmin', N'admin@gmail.com', N'1234')
INSERT [dbo].[Administrators] ([Id], [Name], [Email], [Password]) VALUES (2, N'Fede', N'Fede@hotmail.com', N'Fede1')
SET IDENTITY_INSERT [dbo].[Administrators] OFF
GO
SET IDENTITY_INSERT [dbo].[Agendas] ON 

INSERT [dbo].[Agendas] ([Id], [PsychologistId], [Date], [Count], [IsAvaible]) VALUES (1, 1, CAST(N'2021-06-17T18:49:02.8172256' AS DateTime2), 1, 1)
SET IDENTITY_INSERT [dbo].[Agendas] OFF
GO
SET IDENTITY_INSERT [dbo].[Categories] ON 

INSERT [dbo].[Categories] ([Id], [Name]) VALUES (1, N'Dormir')
INSERT [dbo].[Categories] ([Id], [Name]) VALUES (2, N'Meditar')
INSERT [dbo].[Categories] ([Id], [Name]) VALUES (3, N'Musica')
INSERT [dbo].[Categories] ([Id], [Name]) VALUES (4, N'Cuerpo')
SET IDENTITY_INSERT [dbo].[Categories] OFF
GO
INSERT [dbo].[CategoryPlaylists] ([CategoryId], [PlaylistId]) VALUES (3, 1)
INSERT [dbo].[CategoryPlaylists] ([CategoryId], [PlaylistId]) VALUES (2, 2)
INSERT [dbo].[CategoryPlaylists] ([CategoryId], [PlaylistId]) VALUES (4, 3)
INSERT [dbo].[CategoryPlaylists] ([CategoryId], [PlaylistId]) VALUES (3, 4)
GO
SET IDENTITY_INSERT [dbo].[Consultations] ON 

INSERT [dbo].[Consultations] ([Id], [ProblematicId], [PacientId], [PsychologistId], [Cost], [Duration]) VALUES (1, 1, 1, 1, CAST(0.00 AS Decimal(18, 2)), CAST(1.00 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[Consultations] OFF
GO
SET IDENTITY_INSERT [dbo].[Pacients] ON 

INSERT [dbo].[Pacients] ([Id], [Name], [Surname], [BirthDate], [Email], [Cellphone], [BonusAmount], [BonusApproved], [ConsultationsQuantity], [GeneratedBonus]) VALUES (1, N'Macarena', N'Segade', CAST(N'1995-08-15T03:00:00.0000000' AS DateTime2), N'Maca@maca.com', N'098342972', CAST(0.00 AS Decimal(18, 2)), 0, 1, 0)
SET IDENTITY_INSERT [dbo].[Pacients] OFF
GO
INSERT [dbo].[PlayableContentCategories] ([CategoryId], [PlayableContentId]) VALUES (3, 1)
INSERT [dbo].[PlayableContentCategories] ([CategoryId], [PlayableContentId]) VALUES (2, 2)
INSERT [dbo].[PlayableContentCategories] ([CategoryId], [PlayableContentId]) VALUES (4, 3)
INSERT [dbo].[PlayableContentCategories] ([CategoryId], [PlayableContentId]) VALUES (3, 4)
INSERT [dbo].[PlayableContentCategories] ([CategoryId], [PlayableContentId]) VALUES (3, 5)
GO
INSERT [dbo].[PlayableContentPlaylists] ([PlaylistId], [PlayableContentId]) VALUES (1, 1)
INSERT [dbo].[PlayableContentPlaylists] ([PlaylistId], [PlayableContentId]) VALUES (1, 4)
INSERT [dbo].[PlayableContentPlaylists] ([PlaylistId], [PlayableContentId]) VALUES (2, 2)
INSERT [dbo].[PlayableContentPlaylists] ([PlaylistId], [PlayableContentId]) VALUES (3, 3)
INSERT [dbo].[PlayableContentPlaylists] ([PlaylistId], [PlayableContentId]) VALUES (4, 5)
GO
SET IDENTITY_INSERT [dbo].[PlayableContents] ON 

INSERT [dbo].[PlayableContents] ([Id], [Name], [Duration], [CreatorName], [ImageUrl], [Url], [PlayableContentTypeId]) VALUES (1, N'Alucinate', CAST(N'00:05:00' AS Time), N'Dua Lipa', NULL, N'https://ia801609.us.archive.org/16/items/nusratcollection_20170414_0953/Man%20Atkiya%20Beparwah%20De%20Naal%20Nusrat%20Fateh%20Ali%20Khan.mp3', 1)
INSERT [dbo].[PlayableContents] ([Id], [Name], [Duration], [CreatorName], [ImageUrl], [Url], [PlayableContentTypeId]) VALUES (2, N'Perfect', CAST(N'00:03:05' AS Time), N'Ed Sheeran', NULL, N'https://ia801609.us.archive.org/16/items/nusratcollection_20170414_0953/Man%20Atkiya%20Beparwah%20De%20Naal%20Nusrat%20Fateh%20Ali%20Khan.mp3', 1)
INSERT [dbo].[PlayableContents] ([Id], [Name], [Duration], [CreatorName], [ImageUrl], [Url], [PlayableContentTypeId]) VALUES (3, N'Joe Roggan Podcast', CAST(N'02:00:00' AS Time), N'Joe Roggan', NULL, N'https://ia801609.us.archive.org/16/items/nusratcollection_20170414_0953/Man%20Atkiya%20Beparwah%20De%20Naal%20Nusrat%20Fateh%20Ali%20Khan.mp3', 1)
INSERT [dbo].[PlayableContents] ([Id], [Name], [Duration], [CreatorName], [ImageUrl], [Url], [PlayableContentTypeId]) VALUES (4, N'La manteca', CAST(N'00:07:00' AS Time), N'Lit Killah', NULL, N'https://www.youtube.com/embed/5qDgZNQ7XcU', 2)
INSERT [dbo].[PlayableContents] ([Id], [Name], [Duration], [CreatorName], [ImageUrl], [Url], [PlayableContentTypeId]) VALUES (5, N'Reaccionando a Eladio Carrio', CAST(N'00:15:00' AS Time), N'Coscu', NULL, N'https://www.youtube.com/embed/zllMZFGTkR0', 2)
SET IDENTITY_INSERT [dbo].[PlayableContents] OFF
GO
SET IDENTITY_INSERT [dbo].[PlayableContentTypes] ON 

INSERT [dbo].[PlayableContentTypes] ([Type], [Name]) VALUES (1, N'Audio')
INSERT [dbo].[PlayableContentTypes] ([Type], [Name]) VALUES (2, N'Video')
SET IDENTITY_INSERT [dbo].[PlayableContentTypes] OFF
GO
SET IDENTITY_INSERT [dbo].[Playlists] ON 

INSERT [dbo].[Playlists] ([Id], [Description], [Name]) VALUES (1, N'Pop Hits', N'Pop Hits')
INSERT [dbo].[Playlists] ([Id], [Description], [Name]) VALUES (2, N'Best Ed Sheeran songs', N'This is Ed Sheeran')
INSERT [dbo].[Playlists] ([Id], [Description], [Name]) VALUES (3, N'Best Podcasts', N'Podcasts')
INSERT [dbo].[Playlists] ([Id], [Description], [Name]) VALUES (4, N'Las mejores reacciones a videos', N'Reacciones')
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
INSERT [dbo].[PsychologistProblematics] ([PsychologistId], [ProblematicId]) VALUES (1, 2)
INSERT [dbo].[PsychologistProblematics] ([PsychologistId], [ProblematicId]) VALUES (1, 3)
INSERT [dbo].[PsychologistProblematics] ([PsychologistId], [ProblematicId]) VALUES (2, 5)
INSERT [dbo].[PsychologistProblematics] ([PsychologistId], [ProblematicId]) VALUES (2, 6)
INSERT [dbo].[PsychologistProblematics] ([PsychologistId], [ProblematicId]) VALUES (2, 7)
GO
SET IDENTITY_INSERT [dbo].[Psychologists] ON 

INSERT [dbo].[Psychologists] ([Id], [Name], [ConsultationMode], [Direction], [CreationDate], [Fee]) VALUES (1, N'Juan', N'Presencial', N'Bulevar España 8888', CAST(N'2021-06-17T18:47:03.1052797' AS DateTime2), 2000)
INSERT [dbo].[Psychologists] ([Id], [Name], [ConsultationMode], [Direction], [CreationDate], [Fee]) VALUES (2, N'Fede', N'Virtual', N'Rio Negro 8156', CAST(N'2021-06-17T18:47:48.4536861' AS DateTime2), 750)
SET IDENTITY_INSERT [dbo].[Psychologists] OFF
GO
SET IDENTITY_INSERT [dbo].[Sessions] ON 

INSERT [dbo].[Sessions] ([Id], [Token], [AdministratorId]) VALUES (1, N'bcc97a08-5759-41cb-bb45-1adaf9533381', 1)
INSERT [dbo].[Sessions] ([Id], [Token], [AdministratorId]) VALUES (2, N'2dc1ceed-09c5-4eca-8964-8eeffaa5b3c5', 1)
SET IDENTITY_INSERT [dbo].[Sessions] OFF
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
