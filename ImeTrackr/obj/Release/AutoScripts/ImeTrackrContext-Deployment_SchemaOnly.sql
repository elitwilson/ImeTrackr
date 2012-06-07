CREATE TABLE [dbo].[Contacts](
	[Id] [int] IDENTITY(7,1) NOT NULL,
	[OrganizationId] [int] NULL,
	[FirstName] [nvarchar](4000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[LastName] [nvarchar](4000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[PhoneNumber] [nvarchar](4000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[JobTitle] [nvarchar](4000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Email] [nvarchar](4000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Notes] [nvarchar](4000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
)

GO
ALTER TABLE [dbo].[Contacts] ADD  CONSTRAINT [PK__Contacts__0000000000000056] PRIMARY KEY 
(
	[Id]
)
GO
CREATE TABLE [dbo].[EdmMetadata](
	[Id] [int] IDENTITY(2,1) NOT NULL,
	[ModelHash] [nvarchar](4000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
)

GO
ALTER TABLE [dbo].[EdmMetadata] ADD  CONSTRAINT [PK__EdmMetadata__0000000000000082] PRIMARY KEY 
(
	[Id]
)
GO
CREATE TABLE [dbo].[Evaluations](
	[Id] [int] IDENTITY(6,1) NOT NULL,
	[PlaintiffId] [int] NULL,
	[ContactId] [int] NULL,
	[TechId] [int] NULL,
	[OrganizationId] [int] NULL,
	[Notes] [nvarchar](4000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[DayOne] [datetime] NULL,
	[DayTwo] [datetime] NULL,
	[CaseNumber] [nvarchar](4000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[CaseName] [nvarchar](4000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[IsComplete] [bit] NOT NULL
)

GO
ALTER TABLE [dbo].[Evaluations] ADD  CONSTRAINT [PK__Evaluations__0000000000000018] PRIMARY KEY 
(
	[Id]
)
GO
CREATE TABLE [dbo].[Organizations](
	[Id] [int] IDENTITY(6,1) NOT NULL,
	[Name] [nvarchar](4000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[StAddress] [nvarchar](4000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[City] [nvarchar](4000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[State] [nvarchar](4000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Zip] [int] NOT NULL,
	[MainPhone] [nvarchar](4000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Fax] [nvarchar](4000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
)

GO
ALTER TABLE [dbo].[Organizations] ADD  CONSTRAINT [PK__Organizations__0000000000000040] PRIMARY KEY 
(
	[Id]
)
GO
CREATE TABLE [dbo].[PhoneCalls](
	[Id] [int] IDENTITY(8,1) NOT NULL,
	[OrganizationId] [int] NOT NULL,
	[ContactId] [int] NOT NULL,
	[PlaintiffId] [int] NULL,
	[Date] [datetime] NULL,
	[Message] [nvarchar](4000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[IsComplete] [bit] NOT NULL
)

GO
ALTER TABLE [dbo].[PhoneCalls] ADD  CONSTRAINT [PK__PhoneCalls__000000000000006A] PRIMARY KEY 
(
	[Id]
)
GO
CREATE TABLE [dbo].[Plaintiffs](
	[Id] [int] IDENTITY(12,1) NOT NULL,
	[FirstName] [nvarchar](4000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[LastName] [nvarchar](4000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[DOB] [datetime] NULL,
	[SSN] [int] NOT NULL,
	[Contact_Id] [int] NULL
)

GO
ALTER TABLE [dbo].[Plaintiffs] ADD  CONSTRAINT [PK__Plaintiffs__000000000000002A] PRIMARY KEY 
(
	[Id]
)
GO
CREATE TABLE [dbo].[Teches](
	[Id] [int] IDENTITY(3,1) NOT NULL,
	[FirstName] [nvarchar](4000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[LastName] [nvarchar](4000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Initials] [nvarchar](4000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
)

GO
ALTER TABLE [dbo].[Teches] ADD  CONSTRAINT [PK__Teches__0000000000000078] PRIMARY KEY 
(
	[Id]
)
GO
ALTER TABLE [dbo].[Contacts]  ADD  CONSTRAINT [Contact_Organization] FOREIGN KEY([OrganizationId])
REFERENCES [Organizations] ([Id])
GO
ALTER TABLE [dbo].[Evaluations]  ADD  CONSTRAINT [Contact_Evaluations] FOREIGN KEY([ContactId])
REFERENCES [Contacts] ([Id])
GO
ALTER TABLE [dbo].[Evaluations]  ADD  CONSTRAINT [Organization_Evaluations] FOREIGN KEY([OrganizationId])
REFERENCES [Organizations] ([Id])
GO
ALTER TABLE [dbo].[Evaluations]  ADD  CONSTRAINT [Plaintiff_Evaluations] FOREIGN KEY([PlaintiffId])
REFERENCES [Plaintiffs] ([Id])
GO
ALTER TABLE [dbo].[Evaluations]  ADD  CONSTRAINT [Tech_Evaluations] FOREIGN KEY([TechId])
REFERENCES [Teches] ([Id])
GO
ALTER TABLE [dbo].[PhoneCalls]  ADD  CONSTRAINT [PhoneCall_Contact] FOREIGN KEY([ContactId])
REFERENCES [Contacts] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PhoneCalls]  ADD  CONSTRAINT [PhoneCall_Plaintiff] FOREIGN KEY([PlaintiffId])
REFERENCES [Plaintiffs] ([Id])
GO
ALTER TABLE [dbo].[Plaintiffs]  ADD  CONSTRAINT [Contact_Plaintiffs] FOREIGN KEY([Contact_Id])
REFERENCES [Contacts] ([Id])
GO
