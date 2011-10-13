CREATE TABLE [dbo].[ContactEvaluations](
	[Contact_Id] [int] NOT NULL,
	[Evaluation_Id] [int] NOT NULL
)

GO
ALTER TABLE [dbo].[ContactEvaluations] ADD  CONSTRAINT [PK__ContactEvaluations__000000000000008A] PRIMARY KEY 
(
	[Contact_Id],
	[Evaluation_Id]
)
GO
CREATE TABLE [dbo].[Contacts](
	[Id] [int] IDENTITY(3,1) NOT NULL,
	[OrganizationId] [int] NOT NULL,
	[FirstName] [nvarchar](4000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[LastName] [nvarchar](4000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[PhoneNumber] [nvarchar](4000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[JobTitle] [nvarchar](4000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
)

GO
ALTER TABLE [dbo].[Contacts] ADD  CONSTRAINT [PK__Contacts__000000000000003A] PRIMARY KEY 
(
	[Id]
)
GO
CREATE TABLE [dbo].[EdmMetadata](
	[Id] [int] IDENTITY(2,1) NOT NULL,
	[ModelHash] [nvarchar](4000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
)

GO
ALTER TABLE [dbo].[EdmMetadata] ADD  CONSTRAINT [PK__EdmMetadata__0000000000000080] PRIMARY KEY 
(
	[Id]
)
GO
CREATE TABLE [dbo].[Evaluations](
	[Id] [int] IDENTITY(4,1) NOT NULL,
	[PlaintiffId] [int] NULL,
	[OrganizationId] [int] NULL,
	[ContactId] [int] NULL,
	[Notes] [nvarchar](4000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[DayOne] [datetime] NULL,
	[DateTwo] [datetime] NULL,
	[CaseNumber] [nvarchar](4000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[CaseName] [nvarchar](4000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[IsComplete] [bit] NOT NULL
)

GO
ALTER TABLE [dbo].[Evaluations] ADD  CONSTRAINT [PK__Evaluations__0000000000000016] PRIMARY KEY 
(
	[Id]
)
GO
CREATE TABLE [dbo].[EvaluationViewModels](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](4000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[LastName] [nvarchar](4000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[DOB] [datetime] NULL,
	[SSN] [int] NOT NULL,
	[CaseName] [nvarchar](4000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[CaseNumber] [nvarchar](4000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ContactId] [int] NOT NULL,
	[OrganizationId] [int] NOT NULL
)

GO
ALTER TABLE [dbo].[EvaluationViewModels] ADD  CONSTRAINT [PK__EvaluationViewModels__0000000000000076] PRIMARY KEY 
(
	[Id]
)
GO
CREATE TABLE [dbo].[Organizations](
	[Id] [int] IDENTITY(3,1) NOT NULL,
	[Name] [nvarchar](4000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[StAddress] [nvarchar](4000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[City] [nvarchar](4000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[State] [nvarchar](4000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Zip] [int] NOT NULL,
	[MainPhone] [nvarchar](4000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Fax] [nvarchar](4000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
)

GO
ALTER TABLE [dbo].[Organizations] ADD  CONSTRAINT [PK__Organizations__000000000000005E] PRIMARY KEY 
(
	[Id]
)
GO
CREATE TABLE [dbo].[PhoneCalls](
	[Id] [int] IDENTITY(3,1) NOT NULL,
	[ContactId] [int] NOT NULL,
	[Date] [datetime] NULL,
	[Message] [nvarchar](4000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
)

GO
ALTER TABLE [dbo].[PhoneCalls] ADD  CONSTRAINT [PK__PhoneCalls__0000000000000048] PRIMARY KEY 
(
	[Id]
)
GO
CREATE TABLE [dbo].[Plaintiffs](
	[Id] [int] IDENTITY(5,1) NOT NULL,
	[ContactId] [int] NULL,
	[FirstName] [nvarchar](4000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[LastName] [nvarchar](4000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[DOB] [datetime] NULL,
	[SSN] [int] NOT NULL
)

GO
ALTER TABLE [dbo].[Plaintiffs] ADD  CONSTRAINT [PK__Plaintiffs__0000000000000028] PRIMARY KEY 
(
	[Id]
)
GO
ALTER TABLE [dbo].[ContactEvaluations]  ADD  CONSTRAINT [Contact_Evaluations_Source] FOREIGN KEY([Contact_Id])
REFERENCES [Contacts] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ContactEvaluations]  ADD  CONSTRAINT [Contact_Evaluations_Target] FOREIGN KEY([Evaluation_Id])
REFERENCES [Evaluations] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Contacts]  ADD  CONSTRAINT [Organization_Contacts] FOREIGN KEY([OrganizationId])
REFERENCES [Organizations] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Evaluations]  ADD  CONSTRAINT [Organization_Evaluations] FOREIGN KEY([OrganizationId])
REFERENCES [Organizations] ([Id])
GO
ALTER TABLE [dbo].[Evaluations]  ADD  CONSTRAINT [Plaintiff_Evaluations] FOREIGN KEY([PlaintiffId])
REFERENCES [Plaintiffs] ([Id])
GO
ALTER TABLE [dbo].[PhoneCalls]  ADD  CONSTRAINT [PhoneCall_Contact] FOREIGN KEY([ContactId])
REFERENCES [Contacts] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Plaintiffs]  ADD  CONSTRAINT [Contact_Plaintiffs] FOREIGN KEY([ContactId])
REFERENCES [Contacts] ([Id])
GO
