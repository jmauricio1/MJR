CREATE TABLE [dbo].[Athletes]
(
	[ID]	INT IDENTITY (1, 1)	NOT NULL,
	[FName]	NVARCHAR(50)	NOT NULL,
	[LName] NVARCHAR(50)	NOT NULL,
	[Gender] NVARCHAR(20)	NOT NULL,
	CONSTRAINT [PK_dbo.Athletes] PRIMARY KEY CLUSTERED ([ID] ASC)
);

CREATE TABLE [dbo].[Locations]
(
	[ID] INT IDENTITY (1, 1) NOT NULL,
	[Name] NVARCHAR(150) NOT NULL,
	CONSTRAINT [PK_dbo.Locations] PRIMARY KEY CLUSTERED ([ID] ASC)
);

CREATE TABLE [dbo].[Events]
(
	[ID] INT IDENTITY(1, 1) NOT NULL,
	[EventName] NVARCHAR(100) NOT NULL,
	CONSTRAINT [PK_dbo.Events] PRIMARY KEY CLUSTERED ([ID] ASC)
);

CREATE TABLE [dbo].[Coaches]
(
	[ID] INT IDENTITY(1, 1) NOT NULL,
	[FName]	NVARCHAR(50)	NOT NULL,
	[LName] NVARCHAR(50)	NOT NULL,
	CONSTRAINT [PK_dbo.Coaches] PRIMARY KEY CLUSTERED ([ID] ASC),
);

CREATE TABLE [dbo].[Teams]
(
	[ID] INT IDENTITY(1, 1) NOT NULL,
	[SchoolName] NVARCHAR(150) NOT NULL,
	[CID] INT	NOT NULL,
	CONSTRAINT [PK_dbo.Teams] PRIMARY KEY CLUSTERED ([ID] ASC),
	CONSTRAINT [FK_dbo.Teams_dbo.Coaches_ID] FOREIGN KEY ([CID]) REFERENCES [dbo].[Coaches]([ID])
);

CREATE TABLE [dbo].[TeamAthletes]
(
	[ID] INT IDENTITY(1, 1) NOT NULL,
	[AID] INT NOT NULL,
	[TID] INT NOT NULL,
	CONSTRAINT [PK_dbo.TeamAthletes] PRIMARY KEY CLUSTERED ([ID] ASC),
	CONSTRAINT [FK_dbo.TeamAthletes_dbo.Athletes_ID] FOREIGN KEY ([AID]) REFERENCES [dbo].[Athletes]([ID]),
	CONSTRAINT [FK_dbo.TeamAthletes_dbo.Coaches_ID] FOREIGN KEY ([TID]) REFERENCES [dbo].[Coaches]([ID])
);

CREATE TABLE [dbo].[AthleteEvents]
(
	[ID] INT IDENTITY(1, 1) NOT NULL,
	[AID] INT NOT NULL,
	[EID] INT NOT NULL,
	CONSTRAINT [PK_dbo.AthleteEvents] PRIMARY KEY CLUSTERED ([ID] ASC),
	CONSTRAINT [FK_dbo.AthleteEvents_dbo.Athletes_ID] FOREIGN KEY ([AID]) REFERENCES [dbo].[Athletes]([ID]),
	CONSTRAINT [FK_dbo.AthleteEvents_dbo.Events_ID] FOREIGN KEY ([EID]) REFERENCES [dbo].[Events]([ID])
);

CREATE TABLE [dbo].[AthleteResults]
(
	[ID] INT IDENTITY(1, 1) NOT NULL,
	[AID] INT NOT NULL,
	[EID] INT NOT NULL,
	[EventDate] DATETIME NOT NULL,
	[LID] INT NOT NULL,
	[RaceTime] REAL NOT NULL,
	CONSTRAINT [PK_dbo.AthleteResults] PRIMARY KEY CLUSTERED ([ID] ASC),
	CONSTRAINT [FK_dbo.AthleteResults_dbo.Athletes_ID] FOREIGN KEY ([AID]) REFERENCES [dbo].[Athletes]([ID]),
	CONSTRAINT [FK_dbo.AthleteResults_dbo.Events_ID] FOREIGN KEY ([EID]) REFERENCES [dbo].[Events]([ID]),
	CONSTRAINT [FK_dbo.AthleteResults_dbo.Locations_ID] FOREIGN KEY ([LID]) REFERENCES [dbo].[Locations]([ID])
);

-- #######################################
-- #             Identity Tables         #
-- #######################################

-- ############# AspNetRoles #############
CREATE TABLE [dbo].[AspNetRoles]
(
    [Id]   NVARCHAR (128) NOT NULL,
    [Name] NVARCHAR (256) NOT NULL,
    CONSTRAINT [PK_dbo.AspNetRoles] PRIMARY KEY CLUSTERED ([Id] ASC)
);
GO
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex]
    ON [dbo].[AspNetRoles]([Name] ASC);

-- ############# AspNetUsers #############
CREATE TABLE [dbo].[AspNetUsers]
(
    [Id]                   NVARCHAR (128) NOT NULL,
    [Email]                NVARCHAR (256) NULL,
    [EmailConfirmed]       BIT            NOT NULL,
    [PasswordHash]         NVARCHAR (MAX) NULL,
    [SecurityStamp]        NVARCHAR (MAX) NULL,
    [PhoneNumber]          NVARCHAR (MAX) NULL,
    [PhoneNumberConfirmed] BIT            NOT NULL,
    [TwoFactorEnabled]     BIT            NOT NULL,
    [LockoutEndDateUtc]    DATETIME       NULL,
    [LockoutEnabled]       BIT            NOT NULL,
    [AccessFailedCount]    INT            NOT NULL,
    [UserName]             NVARCHAR (256) NOT NULL,
    CONSTRAINT [PK_dbo.AspNetUsers] PRIMARY KEY CLUSTERED ([Id] ASC)
);
GO
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[AspNetUsers]([UserName] ASC);

-- ############# AspNetUserClaims #############
CREATE TABLE [dbo].[AspNetUserClaims]
(
    [Id]         INT            IDENTITY (1, 1) NOT NULL,
    [UserId]     NVARCHAR (128) NOT NULL,
    [ClaimType]  NVARCHAR (MAX) NULL,
    [ClaimValue] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_dbo.AspNetUserClaims] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[AspNetUsers] ([Id]) ON DELETE CASCADE
);
GO
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserClaims]([UserId] ASC);

-- ############# AspNetUserLogins #############
CREATE TABLE [dbo].[AspNetUserLogins]
(
    [LoginProvider] NVARCHAR (128) NOT NULL,
    [ProviderKey]   NVARCHAR (128) NOT NULL,
    [UserId]        NVARCHAR (128) NOT NULL,
    CONSTRAINT [PK_dbo.AspNetUserLogins] PRIMARY KEY CLUSTERED ([LoginProvider] ASC, [ProviderKey] ASC, [UserId] ASC),
    CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[AspNetUsers] ([Id]) ON DELETE CASCADE
);
GO
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserLogins]([UserId] ASC);

-- ############# AspNetUserRoles #############
CREATE TABLE [dbo].[AspNetUserRoles]
(
    [UserId] NVARCHAR (128) NOT NULL,
    [RoleId] NVARCHAR (128) NOT NULL,
    CONSTRAINT [PK_dbo.AspNetUserRoles] PRIMARY KEY CLUSTERED ([UserId] ASC, [RoleId] ASC),
    CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [dbo].[AspNetRoles] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[AspNetUsers] ([Id]) ON DELETE CASCADE
);
GO
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserRoles]([UserId] ASC);
GO
CREATE NONCLUSTERED INDEX [IX_RoleId] ON [dbo].[AspNetUserRoles]([RoleId] ASC);

