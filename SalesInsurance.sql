USE [SalesInsurance]
GO

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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ActivityLog](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MID] [int] NOT NULL,
	[DateTime] [datetime2](7) NULL,
	[Details] [nvarchar](max) NULL,
	[ResponseCode] [int] NOT NULL,
	[ResponseDesc] [nvarchar](max) NULL,
 CONSTRAINT [PK_ActivityLog] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InstallmentPolicy](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PID] [int] NOT NULL,
	[Policy_Id] [nvarchar](max) NOT NULL,
	[Installment_No] [int] NOT NULL,
	[Premium] [real] NULL,
	[Paydate] [datetime2](7) NULL,
	[Created_By] [nvarchar](max) NULL,
	[Created_On] [datetime2](7) NULL,
 CONSTRAINT [PK_InstallmentPolicy] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MasterPolicy](
	[PID] [int] IDENTITY(1,1) NOT NULL,
	[Policy_Id] [nvarchar](max) NOT NULL,
	[Customer_Name] [nvarchar](max) NOT NULL,
	[Date_Of_Birth] [datetime2](7) NOT NULL,
	[Sex] [nvarchar](max) NULL,
	[Id_Card] [nvarchar](max) NULL,
	[Phone_Number] [nvarchar](max) NULL,
	[Premium] [real] NOT NULL,
	[Plan_Type] [nvarchar](max) NULL,
	[Created_By] [nvarchar](max) NULL,
	[Created_Date] [datetime2](7) NOT NULL,
	[Updated_By] [nvarchar](max) NULL,
	[Update_Date] [datetime2](7) NULL,
 CONSTRAINT [PK_MasterPolicy] PRIMARY KEY CLUSTERED 
(
	[PID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MUser](
	[MID] [int] IDENTITY(1,1) NOT NULL,
	[User_Id] [nvarchar](max) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Password] [nvarchar](max) NULL,
	[User_Level] [nvarchar](max) NULL,
	[Created_By] [nvarchar](max) NULL,
	[Created_On] [datetime2](7) NULL,
	[Updated_By] [nvarchar](max) NULL,
	[Update_Date] [datetime2](7) NULL,
 CONSTRAINT [PK_MUser] PRIMARY KEY CLUSTERED 
(
	[MID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20231206074611_MUserAndActivityLog', N'8.0.0')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20231206074735_PolicyAndInstallment', N'8.0.0')
GO
SET IDENTITY_INSERT [dbo].[ActivityLog] ON 
GO
INSERT [dbo].[ActivityLog] ([Id], [MID], [DateTime], [Details], [ResponseCode], [ResponseDesc]) VALUES (2, 1, CAST(N'2023-12-06T08:05:13.1290000' AS DateTime2), N'Testt', 0, NULL)
GO
INSERT [dbo].[ActivityLog] ([Id], [MID], [DateTime], [Details], [ResponseCode], [ResponseDesc]) VALUES (3, 1, CAST(N'2023-12-07T02:01:56.2930000' AS DateTime2), N'string', 0, N'string')
GO
INSERT [dbo].[ActivityLog] ([Id], [MID], [DateTime], [Details], [ResponseCode], [ResponseDesc]) VALUES (5, 1, CAST(N'2023-12-07T07:26:18.2080000' AS DateTime2), N'string', 0, N'string')
GO
INSERT [dbo].[ActivityLog] ([Id], [MID], [DateTime], [Details], [ResponseCode], [ResponseDesc]) VALUES (6, 1, CAST(N'2023-12-07T07:26:18.2080000' AS DateTime2), N'string', 0, N'string')
GO
SET IDENTITY_INSERT [dbo].[ActivityLog] OFF
GO
SET IDENTITY_INSERT [dbo].[InstallmentPolicy] ON 
GO
INSERT [dbo].[InstallmentPolicy] ([Id], [PID], [Policy_Id], [Installment_No], [Premium], [Paydate], [Created_By], [Created_On]) VALUES (1, 1, N'MP12345', 1, 40000, CAST(N'2023-12-07T10:29:14.2900000' AS DateTime2), N'Admin', CAST(N'2023-12-07T10:29:14.2900000' AS DateTime2))
GO
SET IDENTITY_INSERT [dbo].[InstallmentPolicy] OFF
GO
SET IDENTITY_INSERT [dbo].[MasterPolicy] ON 
GO
INSERT [dbo].[MasterPolicy] ([PID], [Policy_Id], [Customer_Name], [Date_Of_Birth], [Sex], [Id_Card], [Phone_Number], [Premium], [Plan_Type], [Created_By], [Created_Date], [Updated_By], [Update_Date]) VALUES (1, N'MP12345', N'Test policy UAT', CAST(N'1990-12-07T00:00:00.0000000' AS DateTime2), N'Pria', N'0192837171212', N'01010101923', 40000, N'MP', N'Admin', CAST(N'2023-12-07T09:23:24.8770000' AS DateTime2), N'Admin', CAST(N'2023-12-07T09:30:00.5160000' AS DateTime2))
GO
SET IDENTITY_INSERT [dbo].[MasterPolicy] OFF
GO
SET IDENTITY_INSERT [dbo].[MUser] ON 
GO
INSERT [dbo].[MUser] ([MID], [User_Id], [Name], [Password], [User_Level], [Created_By], [Created_On], [Updated_By], [Update_Date]) VALUES (1, N'TestUAT', N'Testing Data UAT', N'12345', N'Admin', N'Admin', CAST(N'2023-12-07T01:21:27.2840000' AS DateTime2), NULL, NULL)
GO
INSERT [dbo].[MUser] ([MID], [User_Id], [Name], [Password], [User_Level], [Created_By], [Created_On], [Updated_By], [Update_Date]) VALUES (2, N'WayekUAT', N'string wayek', N'12345', N'Staff', N'Admin', CAST(N'2023-12-07T01:03:28.4690000' AS DateTime2), NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[MUser] OFF
GO
ALTER TABLE [dbo].[ActivityLog]  WITH CHECK ADD  CONSTRAINT [FK_ActivityLog_MUser_MID] FOREIGN KEY([MID])
REFERENCES [dbo].[MUser] ([MID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ActivityLog] CHECK CONSTRAINT [FK_ActivityLog_MUser_MID]
GO
ALTER TABLE [dbo].[InstallmentPolicy]  WITH CHECK ADD  CONSTRAINT [FK_InstallmentPolicy_MasterPolicy_PID] FOREIGN KEY([PID])
REFERENCES [dbo].[MasterPolicy] ([PID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[InstallmentPolicy] CHECK CONSTRAINT [FK_InstallmentPolicy_MasterPolicy_PID]
GO
