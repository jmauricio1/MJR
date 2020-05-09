-- #######################################
-- #             Identity Tables         #
-- #######################################

-- ############# AspNetRoles #############
CREATE TABLE [dbo].[AvatarPaths]
(
    [ID]            INT IDENTITY(1, 1)  NOT NULL,
    [AvatarName]    NVARCHAR(64)        NOT NULL,
    [Path]          NVARCHAR(128)       NOT NULL,
    CONSTRAINT [PK_dbo.AvatarPaths] PRIMARY KEY CLUSTERED ([ID] ASC)
);

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
    [FirstName]            NVARCHAR (128) NOT NULL,
    [LastName]             NVARCHAR (128) NOT NULL,
    [UserName]             NVARCHAR (256) NOT NULL,
    [StateProvince]        NVARCHAR (256) NOT NULL,
    [Country]              NVARCHAR (256) NOT NULL,
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
    [Bio]                  NVARCHAR(256)  NULL,
    [AID]                  INT            NOT NULL,
    CONSTRAINT [PK_dbo.AspNetUsers] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.AspNetUsers_dbo.AvatarPaths_ID] FOREIGN KEY ([AID]) REFERENCES [dbo].[AvatarPaths]([ID]) 
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


-- #######################################
-- #         User Comment Table          #
-- #######################################

CREATE TABLE [dbo].[UserComment]
(
    [Id]            INT             IDENTITY(1,1)   NOT NULL,
    [Username]      NVARCHAR        (64)            NOT NULL,
    [PostDate]      DATE                            NOT NULL,
    [PageFrom]      NVARCHAR        (128)           NOT NULL,
    [AcceptState]   BIT                             NOT NULL,
    [Comment]       NVARCHAR        (1000)          NOT NULL,
    [ReportCount]   INT                             NOT NULL

    CONSTRAINT [PK_dbo.UserComment] PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[Locations]
(
    [Id]                INT IDENTITY(1, 1)      NOT NULL,
    [LocationName]      NVARCHAR(64)            NOT NULL
    
    CONSTRAINT [PK_dbo.Locations] PRIMARY KEY CLUSTERED ([ID] ASC)
);

CREATE TABLE [dbo].[Distances]
(
    [Id]                INT IDENTITY(1, 1)      NOT NULL,
    [DistanceMiles]     BIGINT                  NOT NULL

    CONSTRAINT [PK_dbo.Distances] PRIMARY KEY CLUSTERED ([ID] ASC)
);

CREATE TABLE [dbo].[LocationDistance]
(
    [Id]                INT IDENTITY(1, 1)      NOT NULL,
    [LocationOneId]     INT                     NOT NULL,
    [LocationTwoId]     INT                     NOT NULL,
    [DistanceId]        INT                     NOT NULL

    CONSTRAINT [PK_dbo.LocationDistance] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_dbo.LocationOne_Distance] FOREIGN KEY ([LocationOneId]) REFERENCES [dbo].[Locations]([Id]),
    CONSTRAINT [FK_dbo.LocationTwo_Distance] FOREIGN KEY ([LocationTwoId]) REFERENCES [dbo].[Locations]([Id]),
    CONSTRAINT [FK_dbo.Distance_Location] FOREIGN KEY ([DistanceId]) REFERENCES [dbo].[Distances]([Id])
);

-- #######################################
-- #             Search Tables         #
-- #######################################

CREATE TABLE [dbo].[SearchKeywords]
(
    [Id]   INT IDENTITY (1,1) NOT NULL,
    [Name] NVARCHAR (256) NOT NULL,
    CONSTRAINT [PK_dbo.SearchKeywords] PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[KeywordRelations]
(
    [Id]   INT IDENTITY (1,1) NOT NULL,
    [KeywordId] INT NOT NULL,
    [PageId] INT NOT NULL,
    CONSTRAINT [PK_dbo.KeywordRelations] PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[SitePages]
(
    [Id]   INT IDENTITY (1,1) NOT NULL,
    [Name] NVARCHAR (256) NOT NULL,
    [Link] NVARCHAR (256) NOT NULL,
    [Description] NVARCHAR (256) NOT NULL,
    CONSTRAINT [PK_dbo.SitePages] PRIMARY KEY CLUSTERED ([Id] ASC)
);
GO

-- #######################################
-- #             Fact of the Day Tables         #
-- #######################################

-- ############# AspNetRoles #############
CREATE TABLE [dbo].[FactOfTheDay]
(
    [Id]   INT IDENTITY (1,1) NOT NULL,
    [Text] NVARCHAR (256) NOT NULL,
    [Source] NVARCHAR (256) NOT NULL,
    CONSTRAINT [PK_dbo.FactOfTheDay] PRIMARY KEY CLUSTERED ([Id] ASC)
);
GO
