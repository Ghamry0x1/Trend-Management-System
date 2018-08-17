USE [Trend]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 8/15/2018 1:32:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 8/15/2018 1:32:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
	[User_Id] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 8/15/2018 1:32:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[UserId] [nvarchar](128) NOT NULL,
	[LoginProvider] [nvarchar](128) NOT NULL,
	[ProviderKey] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 8/15/2018 1:32:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](128) NOT NULL,
	[RoleId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 8/15/2018 1:32:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](128) NOT NULL,
	[UserName] [nvarchar](max) NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[Discriminator] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DefBroker]    Script Date: 8/15/2018 1:32:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DefBroker](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[BrokerName] [nvarchar](100) NOT NULL,
	[WebSite] [nvarchar](100) NULL,
	[Email] [nvarchar](100) NULL,
	[Address] [nvarchar](100) NULL,
	[Industry] [nvarchar](100) NULL,
	[FK_CreatorID] [nvarchar](128) NOT NULL,
	[CreationDate] [datetime] NOT NULL,
	[LastModifiedDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Broker_1] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DefClient]    Script Date: 8/15/2018 1:32:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DefClient](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ClientName] [nvarchar](100) NOT NULL,
	[WebSite] [nvarchar](100) NULL,
	[Email] [nvarchar](100) NULL,
	[Address] [nvarchar](100) NULL,
	[Industry] [nvarchar](100) NULL,
	[FK_CreatorID] [nvarchar](128) NOT NULL,
	[CreationDate] [datetime] NOT NULL,
	[LastModifiedDate] [datetime] NOT NULL,
 CONSTRAINT [PK_DefClient] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DefCompany]    Script Date: 8/15/2018 1:32:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DefCompany](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CompanyName] [nvarchar](100) NOT NULL,
	[CompanyAddress] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Company] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DefContact]    Script Date: 8/15/2018 1:32:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DefContact](
	[ID] [int] NOT NULL,
	[FK_DefContactReferenceTypeID] [int] NOT NULL,
	[FK_ReferenceID] [int] NOT NULL,
	[FullName] [nvarchar](100) NOT NULL,
	[Email] [nvarchar](100) NULL,
	[Address] [nvarchar](100) NULL,
	[Position] [nvarchar](100) NULL,
	[Telephone] [nvarchar](15) NULL,
	[Telephone1] [nvarchar](15) NULL,
	[Mobile] [nvarchar](15) NULL,
	[Mobile1] [nvarchar](15) NULL,
	[Fax] [nvarchar](15) NULL,
	[FK_CreatorID] [nvarchar](128) NOT NULL,
	[CreationDate] [datetime] NOT NULL,
	[LastModifiedDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Contact] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DefContactReferenceType]    Script Date: 8/15/2018 1:32:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DefContactReferenceType](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ContactReferenceTypeName] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_ContactType] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DefLandlord]    Script Date: 8/15/2018 1:32:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DefLandlord](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[LandlordName] [nvarchar](100) NOT NULL,
	[WebSite] [nvarchar](100) NULL,
	[Email] [nvarchar](100) NULL,
	[Address] [nvarchar](100) NULL,
	[Industry] [nvarchar](100) NULL,
	[FK_CreatorID] [nvarchar](128) NOT NULL,
	[CreationDate] [datetime] NOT NULL,
	[LastModifiedDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Landlord] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DefModuleStatus]    Script Date: 8/15/2018 1:32:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DefModuleStatus](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[FK_SecModuleID] [int] NOT NULL,
	[ModuleStatusName] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Module_Status] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[HREmployee]    Script Date: 8/15/2018 1:32:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HREmployee](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeName] [nvarchar](100) NOT NULL,
	[Surname] [nvarchar](100) NOT NULL,
	[BirthDate] [date] NOT NULL,
	[IdentificationNumber] [nvarchar](20) NOT NULL,
	[Address] [nvarchar](100) NULL,
	[Telephone] [nvarchar](15) NULL,
 CONSTRAINT [PK_HREmployee] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LedLead]    Script Date: 8/15/2018 1:32:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LedLead](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[FK_DefCompanyID] [int] NOT NULL,
	[LeadSerial] [int] NOT NULL,
	[LeadName] [nvarchar](100) NOT NULL,
	[LeadDate] [datetime] NOT NULL,
	[NewOfficeSize] [decimal](18, 2) NULL,
	[NewOfficeAddress] [nvarchar](150) NULL,
	[ExpectedBudget] [decimal](18, 2) NULL,
	[FK_DefClientID] [int] NOT NULL,
	[FK_DefBrokerID] [int] NULL,
	[FK_BrokerDefContactID] [int] NULL,
	[FK_DefModuleStatusID] [int] NULL,
	[FK_LedLeadSourceID] [int] NULL,
	[FK_AssignedByHREmployeeID] [int] NULL,
	[FK_AssignedToHREmployeeID] [int] NULL,
	[LeadAssignedDate] [datetime] NULL,
	[Notes] [nvarchar](500) NULL,
	[FK_CreatorID] [nvarchar](128) NOT NULL,
	[CreationDate] [datetime] NOT NULL,
	[LastModifiedDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Lead] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LedLeadClientContact]    Script Date: 8/15/2018 1:32:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LedLeadClientContact](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[FK_LedLeadID] [int] NOT NULL,
	[FK_DefContactID] [int] NOT NULL,
	[FK_CreatorID] [nvarchar](128) NOT NULL,
	[CreationDate] [datetime] NOT NULL,
	[LastModifiedDate] [datetime] NOT NULL,
 CONSTRAINT [PK_LedLeadClientContact] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LedLeadFrom]    Script Date: 8/15/2018 1:32:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LedLeadFrom](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[FK_LedLeadID] [int] NOT NULL,
	[FK_HREmployeeID] [int] NOT NULL,
	[FK_CreatorID] [nvarchar](128) NOT NULL,
	[CreationDate] [datetime] NOT NULL,
	[LastModifiedDate] [datetime] NOT NULL,
 CONSTRAINT [PK_LedLeadFrom] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LedLeadSource]    Script Date: 8/15/2018 1:32:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LedLeadSource](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[LeadSourceName] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_LeadSource] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SecModule]    Script Date: 8/15/2018 1:32:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SecModule](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ModuleName] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Module] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [PasswordHash], [SecurityStamp], [Discriminator]) VALUES (N'43584493-d60c-4ade-bda6-39d6394a6f79', N'admin', N'AByxGsW5BbuytPYhU760DX7lCwufZsGUYaich7IJZK9xZG+EWpXBn1CIKd+ufsP8/A==', N'911cc541-b581-456d-a872-e3dae1bbc9a2', N'ApplicationUser')
SET IDENTITY_INSERT [dbo].[DefBroker] ON 

INSERT [dbo].[DefBroker] ([ID], [BrokerName], [WebSite], [Email], [Address], [Industry], [FK_CreatorID], [CreationDate], [LastModifiedDate]) VALUES (1, N'Jak Marco', NULL, NULL, NULL, NULL, N'1', CAST(N'2018-08-15 00:00:00.000' AS DateTime), CAST(N'2018-08-15 00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[DefBroker] OFF
SET IDENTITY_INSERT [dbo].[DefClient] ON 

INSERT [dbo].[DefClient] ([ID], [ClientName], [WebSite], [Email], [Address], [Industry], [FK_CreatorID], [CreationDate], [LastModifiedDate]) VALUES (2, N'Google', N'Google.com', N'gmail@gmail.com', NULL, NULL, N'1', CAST(N'2018-08-15 00:00:00.000' AS DateTime), CAST(N'2018-08-15 00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[DefClient] OFF
SET IDENTITY_INSERT [dbo].[DefCompany] ON 

INSERT [dbo].[DefCompany] ([ID], [CompanyName], [CompanyAddress]) VALUES (1, N'Trend', N'South Africa')
SET IDENTITY_INSERT [dbo].[DefCompany] OFF
INSERT [dbo].[DefContact] ([ID], [FK_DefContactReferenceTypeID], [FK_ReferenceID], [FullName], [Email], [Address], [Position], [Telephone], [Telephone1], [Mobile], [Mobile1], [Fax], [FK_CreatorID], [CreationDate], [LastModifiedDate]) VALUES (1, 1, 2, N'Mahmoud Youssef', N'MYoussef@select.com', N'ElSerag Mall', N'GM', N'010', N'011', N'012', N'015', N'33', N'1', CAST(N'2018-08-15 00:00:00.000' AS DateTime), CAST(N'2018-08-15 00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[DefContactReferenceType] ON 

INSERT [dbo].[DefContactReferenceType] ([ID], [ContactReferenceTypeName]) VALUES (1, N'Client')
INSERT [dbo].[DefContactReferenceType] ([ID], [ContactReferenceTypeName]) VALUES (2, N'Broker')
INSERT [dbo].[DefContactReferenceType] ([ID], [ContactReferenceTypeName]) VALUES (3, N'Landlord')
SET IDENTITY_INSERT [dbo].[DefContactReferenceType] OFF
SET IDENTITY_INSERT [dbo].[LedLead] ON 

INSERT [dbo].[LedLead] ([ID], [FK_DefCompanyID], [LeadSerial], [LeadName], [LeadDate], [NewOfficeSize], [NewOfficeAddress], [ExpectedBudget], [FK_DefClientID], [FK_DefBrokerID], [FK_BrokerDefContactID], [FK_DefModuleStatusID], [FK_LedLeadSourceID], [FK_AssignedByHREmployeeID], [FK_AssignedToHREmployeeID], [LeadAssignedDate], [Notes], [FK_CreatorID], [CreationDate], [LastModifiedDate]) VALUES (1, 1, 1, N'Test Lead', CAST(N'2018-08-15 00:00:00.000' AS DateTime), CAST(180.00 AS Decimal(18, 2)), N'13 Nelson mandela street -Cape Town -south africa', CAST(100000.00 AS Decimal(18, 2)), 2, 1, NULL, NULL, 1, NULL, NULL, NULL, NULL, N'1', CAST(N'2018-08-15 00:00:00.000' AS DateTime), CAST(N'2018-08-15 00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[LedLead] OFF
SET IDENTITY_INSERT [dbo].[LedLeadSource] ON 

INSERT [dbo].[LedLeadSource] ([ID], [LeadSourceName]) VALUES (1, N'Direct')
INSERT [dbo].[LedLeadSource] ([ID], [LeadSourceName]) VALUES (2, N'Broker')
INSERT [dbo].[LedLeadSource] ([ID], [LeadSourceName]) VALUES (3, N'Trend Space')
SET IDENTITY_INSERT [dbo].[LedLeadSource] OFF
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_User_Id] FOREIGN KEY([User_Id])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_User_Id]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[DefContact]  WITH CHECK ADD  CONSTRAINT [FK_DefContact_DefContactReferenceType] FOREIGN KEY([FK_DefContactReferenceTypeID])
REFERENCES [dbo].[DefContactReferenceType] ([ID])
GO
ALTER TABLE [dbo].[DefContact] CHECK CONSTRAINT [FK_DefContact_DefContactReferenceType]
GO
ALTER TABLE [dbo].[DefModuleStatus]  WITH CHECK ADD  CONSTRAINT [FK_DefModuleStatus_SecModule] FOREIGN KEY([FK_SecModuleID])
REFERENCES [dbo].[SecModule] ([ID])
GO
ALTER TABLE [dbo].[DefModuleStatus] CHECK CONSTRAINT [FK_DefModuleStatus_SecModule]
GO
ALTER TABLE [dbo].[LedLead]  WITH CHECK ADD  CONSTRAINT [FK_LedLead_DefBroker] FOREIGN KEY([FK_DefBrokerID])
REFERENCES [dbo].[DefBroker] ([ID])
GO
ALTER TABLE [dbo].[LedLead] CHECK CONSTRAINT [FK_LedLead_DefBroker]
GO
ALTER TABLE [dbo].[LedLead]  WITH CHECK ADD  CONSTRAINT [FK_LedLead_DefClient] FOREIGN KEY([FK_DefClientID])
REFERENCES [dbo].[DefClient] ([ID])
GO
ALTER TABLE [dbo].[LedLead] CHECK CONSTRAINT [FK_LedLead_DefClient]
GO
ALTER TABLE [dbo].[LedLead]  WITH CHECK ADD  CONSTRAINT [FK_LedLead_DefCompany] FOREIGN KEY([FK_DefCompanyID])
REFERENCES [dbo].[DefCompany] ([ID])
GO
ALTER TABLE [dbo].[LedLead] CHECK CONSTRAINT [FK_LedLead_DefCompany]
GO
ALTER TABLE [dbo].[LedLead]  WITH CHECK ADD  CONSTRAINT [FK_LedLead_DefContact] FOREIGN KEY([FK_BrokerDefContactID])
REFERENCES [dbo].[DefContact] ([ID])
GO
ALTER TABLE [dbo].[LedLead] CHECK CONSTRAINT [FK_LedLead_DefContact]
GO
ALTER TABLE [dbo].[LedLead]  WITH CHECK ADD  CONSTRAINT [FK_LedLead_DefModuleStatus] FOREIGN KEY([FK_DefModuleStatusID])
REFERENCES [dbo].[DefModuleStatus] ([ID])
GO
ALTER TABLE [dbo].[LedLead] CHECK CONSTRAINT [FK_LedLead_DefModuleStatus]
GO
ALTER TABLE [dbo].[LedLead]  WITH CHECK ADD  CONSTRAINT [FK_LedLead_HREmployee] FOREIGN KEY([FK_AssignedByHREmployeeID])
REFERENCES [dbo].[HREmployee] ([ID])
GO
ALTER TABLE [dbo].[LedLead] CHECK CONSTRAINT [FK_LedLead_HREmployee]
GO
ALTER TABLE [dbo].[LedLead]  WITH CHECK ADD  CONSTRAINT [FK_LedLead_HREmployee1] FOREIGN KEY([FK_AssignedToHREmployeeID])
REFERENCES [dbo].[HREmployee] ([ID])
GO
ALTER TABLE [dbo].[LedLead] CHECK CONSTRAINT [FK_LedLead_HREmployee1]
GO
ALTER TABLE [dbo].[LedLead]  WITH CHECK ADD  CONSTRAINT [FK_LedLead_LedLeadSource] FOREIGN KEY([FK_LedLeadSourceID])
REFERENCES [dbo].[LedLeadSource] ([ID])
GO
ALTER TABLE [dbo].[LedLead] CHECK CONSTRAINT [FK_LedLead_LedLeadSource]
GO
ALTER TABLE [dbo].[LedLeadClientContact]  WITH CHECK ADD  CONSTRAINT [FK_LedLeadClientContact_DefContact] FOREIGN KEY([FK_DefContactID])
REFERENCES [dbo].[DefContact] ([ID])
GO
ALTER TABLE [dbo].[LedLeadClientContact] CHECK CONSTRAINT [FK_LedLeadClientContact_DefContact]
GO
ALTER TABLE [dbo].[LedLeadClientContact]  WITH CHECK ADD  CONSTRAINT [FK_LedLeadClientContact_LedLead] FOREIGN KEY([FK_LedLeadID])
REFERENCES [dbo].[LedLead] ([ID])
GO
ALTER TABLE [dbo].[LedLeadClientContact] CHECK CONSTRAINT [FK_LedLeadClientContact_LedLead]
GO
ALTER TABLE [dbo].[LedLeadFrom]  WITH CHECK ADD  CONSTRAINT [FK_LedLeadFrom_HREmployee] FOREIGN KEY([FK_HREmployeeID])
REFERENCES [dbo].[HREmployee] ([ID])
GO
ALTER TABLE [dbo].[LedLeadFrom] CHECK CONSTRAINT [FK_LedLeadFrom_HREmployee]
GO
ALTER TABLE [dbo].[LedLeadFrom]  WITH CHECK ADD  CONSTRAINT [FK_LedLeadFrom_LedLead] FOREIGN KEY([FK_LedLeadID])
REFERENCES [dbo].[LedLead] ([ID])
GO
ALTER TABLE [dbo].[LedLeadFrom] CHECK CONSTRAINT [FK_LedLeadFrom_LedLead]
GO
