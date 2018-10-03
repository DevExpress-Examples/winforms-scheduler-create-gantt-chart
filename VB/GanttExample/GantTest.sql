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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Appointments] ON 

GO
INSERT [dbo].[Appointments] ([UniqueId], [Type], [StartDate], [EndDate], [AllDay], [Subject], [Location], [Description], [Status], [Label], [ResourceId], [ResourceIds], [ReminderInfo], [RecurrenceInfo], [PercentComplete], [CustomField1]) VALUES (1, 0, CAST(N'2016-11-03 00:00:00' AS SmallDateTime), CAST(N'2016-11-05 00:00:00' AS SmallDateTime), 1, N'Spec', N'', N'', 0, 1, 2, NULL, N'', NULL, 100, NULL)
GO
INSERT [dbo].[Appointments] ([UniqueId], [Type], [StartDate], [EndDate], [AllDay], [Subject], [Location], [Description], [Status], [Label], [ResourceId], [ResourceIds], [ReminderInfo], [RecurrenceInfo], [PercentComplete], [CustomField1]) VALUES (2, 0, CAST(N'2016-11-07 00:00:00' AS SmallDateTime), CAST(N'2016-11-11 00:00:00' AS SmallDateTime), 1, N'Deployment', N'', N'', 0, 2, 4, NULL, N'', NULL, 50, NULL)
GO
INSERT [dbo].[Appointments] ([UniqueId], [Type], [StartDate], [EndDate], [AllDay], [Subject], [Location], [Description], [Status], [Label], [ResourceId], [ResourceIds], [ReminderInfo], [RecurrenceInfo], [PercentComplete], [CustomField1]) VALUES (3, 0, CAST(N'2016-11-08 00:00:00' AS SmallDateTime), CAST(N'2016-11-11 00:00:00' AS SmallDateTime), 1, N'Testing', N'', N'', 0, 3, 9, NULL, N'', NULL, 30, NULL)
GO
SET IDENTITY_INSERT [dbo].[Appointments] OFF
GO
SET IDENTITY_INSERT [dbo].[Resources] ON 

GO
INSERT [dbo].[Resources] ([Id], [IdSort], [ParentId], [Description], [Color], [Image], [CustomField1]) VALUES (1, 10, NULL, N'Project Deployment', NULL, NULL, NULL)
GO
INSERT [dbo].[Resources] ([Id], [IdSort], [ParentId], [Description], [Color], [Image], [CustomField1]) VALUES (2, 20, 1, N'Specifications', NULL, NULL, NULL)
GO
INSERT [dbo].[Resources] ([Id], [IdSort], [ParentId], [Description], [Color], [Image], [CustomField1]) VALUES (3, 30, 1, N'Spike Solution', NULL, NULL, NULL)
GO
INSERT [dbo].[Resources] ([Id], [IdSort], [ParentId], [Description], [Color], [Image], [CustomField1]) VALUES (4, 40, 1, N'Deployment', NULL, NULL, NULL)
GO
INSERT [dbo].[Resources] ([Id], [IdSort], [ParentId], [Description], [Color], [Image], [CustomField1]) VALUES (5, 50, 1, N'Performance', NULL, NULL, NULL)
GO
INSERT [dbo].[Resources] ([Id], [IdSort], [ParentId], [Description], [Color], [Image], [CustomField1]) VALUES (6, 60, NULL, N'Demos and Docs', NULL, NULL, NULL)
GO
INSERT [dbo].[Resources] ([Id], [IdSort], [ParentId], [Description], [Color], [Image], [CustomField1]) VALUES (7, 70, 6, N'Demos', NULL, NULL, NULL)
GO
INSERT [dbo].[Resources] ([Id], [IdSort], [ParentId], [Description], [Color], [Image], [CustomField1]) VALUES (8, 80, 6, N'Docs', NULL, NULL, NULL)
GO
INSERT [dbo].[Resources] ([Id], [IdSort], [ParentId], [Description], [Color], [Image], [CustomField1]) VALUES (9, 90, 1, N'Testing', NULL, NULL, NULL)
GO
INSERT [dbo].[Resources] ([Id], [IdSort], [ParentId], [Description], [Color], [Image], [CustomField1]) VALUES (10, 100, 5, N'Code Refactoring', NULL, NULL, NULL)
GO
INSERT [dbo].[Resources] ([Id], [IdSort], [ParentId], [Description], [Color], [Image], [CustomField1]) VALUES (11, 110, 5, N'Optimization', NULL, NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[Resources] OFF
GO
SET IDENTITY_INSERT [dbo].[TaskDependencies] ON 

GO
INSERT [dbo].[TaskDependencies] ([Id], [ParentId], [DependentId], [Type]) VALUES (1, 1, 2, 0)
GO
INSERT [dbo].[TaskDependencies] ([Id], [ParentId], [DependentId], [Type]) VALUES (2, 1, 3, 0)
GO
SET IDENTITY_INSERT [dbo].[TaskDependencies] OFF
GO
