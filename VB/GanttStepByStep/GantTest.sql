USE [GantTest]
GO
/****** Object:  Table [dbo].[TaskDependencies]    Script Date: 10/28/2011 11:20:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TaskDependencies](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ParentId] [int] NULL,
	[DependentId] [int] NULL,
	[Type] [int] NOT NULL,
 CONSTRAINT [PK_TaskDependencies] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[TaskDependencies] ON
INSERT [dbo].[TaskDependencies] ([Id], [ParentId], [DependentId], [Type]) VALUES (1, 1, 2, 0)
INSERT [dbo].[TaskDependencies] ([Id], [ParentId], [DependentId], [Type]) VALUES (2, 1, 3, 0)
SET IDENTITY_INSERT [dbo].[TaskDependencies] OFF
/****** Object:  Table [dbo].[Resources]    Script Date: 10/28/2011 11:20:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Resources](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdSort] [int] NULL,
	[ParentId] [int] NULL,
	[Description] [nvarchar](max) NULL,
	[Color] [int] NULL,
	[Image] [image] NULL,
	[CustomField1] [nvarchar](max) NULL,
 CONSTRAINT [PK_Resources] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Resources] ON
INSERT [dbo].[Resources] ([Id], [IdSort], [ParentId], [Description], [Color], [Image], [CustomField1]) VALUES (1, 10, NULL, N'Project Deployment', NULL, NULL, NULL)
INSERT [dbo].[Resources] ([Id], [IdSort], [ParentId], [Description], [Color], [Image], [CustomField1]) VALUES (2, 20, 1, N'Specifications', NULL, NULL, NULL)
INSERT [dbo].[Resources] ([Id], [IdSort], [ParentId], [Description], [Color], [Image], [CustomField1]) VALUES (3, 30, 1, N'Spike Solution', NULL, NULL, NULL)
INSERT [dbo].[Resources] ([Id], [IdSort], [ParentId], [Description], [Color], [Image], [CustomField1]) VALUES (4, 40, 1, N'Deployment', NULL, NULL, NULL)
INSERT [dbo].[Resources] ([Id], [IdSort], [ParentId], [Description], [Color], [Image], [CustomField1]) VALUES (5, 50, 1, N'Performance', NULL, NULL, NULL)
INSERT [dbo].[Resources] ([Id], [IdSort], [ParentId], [Description], [Color], [Image], [CustomField1]) VALUES (6, 60, NULL, N'Demos and Docs', NULL, NULL, NULL)
INSERT [dbo].[Resources] ([Id], [IdSort], [ParentId], [Description], [Color], [Image], [CustomField1]) VALUES (7, 70, 6, N'Demos', NULL, NULL, NULL)
INSERT [dbo].[Resources] ([Id], [IdSort], [ParentId], [Description], [Color], [Image], [CustomField1]) VALUES (8, 80, 6, N'Docs', NULL, NULL, NULL)
INSERT [dbo].[Resources] ([Id], [IdSort], [ParentId], [Description], [Color], [Image], [CustomField1]) VALUES (9, 90, 1, N'Testind', NULL, NULL, NULL)
INSERT [dbo].[Resources] ([Id], [IdSort], [ParentId], [Description], [Color], [Image], [CustomField1]) VALUES (10, 100, 5, N'Code Refactoring', NULL, NULL, NULL)
INSERT [dbo].[Resources] ([Id], [IdSort], [ParentId], [Description], [Color], [Image], [CustomField1]) VALUES (11, 110, 5, N'Optimization', NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Resources] OFF
/****** Object:  Table [dbo].[Appointments]    Script Date: 10/28/2011 11:20:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Appointments](
	[UniqueId] [int] IDENTITY(1,1) NOT NULL,
	[Type] [int] NULL,
	[StartDate] [smalldatetime] NULL,
	[EndDate] [smalldatetime] NULL,
	[AllDay] [bit] NULL,
	[Subject] [nvarchar](max) NULL,
	[Location] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[Status] [int] NULL,
	[Label] [int] NULL,
	[ResourceId] [int] NULL,
	[ResourceIds] [nvarchar](max) NULL,
	[ReminderInfo] [nvarchar](max) NULL,
	[RecurrenceInfo] [nvarchar](max) NULL,
	[PercentComplete] [int] NULL,
	[CustomField1] [nvarchar](max) NULL,
 CONSTRAINT [PK_Appointments] PRIMARY KEY CLUSTERED 
(
	[UniqueId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Appointments] ON
INSERT [dbo].[Appointments] ([UniqueId], [Type], [StartDate], [EndDate], [AllDay], [Subject], [Location], [Description], [Status], [Label], [ResourceId], [ResourceIds], [ReminderInfo], [RecurrenceInfo], [PercentComplete], [CustomField1]) VALUES (1, 0, CAST(0x9F890000 AS SmallDateTime), CAST(0x9F8B0000 AS SmallDateTime), 1, N'Spec', N'', N'', 0, 1, 2, NULL, N'', NULL, 100, NULL)
INSERT [dbo].[Appointments] ([UniqueId], [Type], [StartDate], [EndDate], [AllDay], [Subject], [Location], [Description], [Status], [Label], [ResourceId], [ResourceIds], [ReminderInfo], [RecurrenceInfo], [PercentComplete], [CustomField1]) VALUES (2, 0, CAST(0x9F8D0000 AS SmallDateTime), CAST(0x9F910000 AS SmallDateTime), 1, N'Deployment', N'', N'', 0, 2, 4, NULL, N'', NULL, 50, NULL)
INSERT [dbo].[Appointments] ([UniqueId], [Type], [StartDate], [EndDate], [AllDay], [Subject], [Location], [Description], [Status], [Label], [ResourceId], [ResourceIds], [ReminderInfo], [RecurrenceInfo], [PercentComplete], [CustomField1]) VALUES (3, 0, CAST(0x9F8E0000 AS SmallDateTime), CAST(0x9F910000 AS SmallDateTime), 1, N'Testing', N'', N'', 0, 3, 9, NULL, N'', NULL, 30, NULL)
SET IDENTITY_INSERT [dbo].[Appointments] OFF
