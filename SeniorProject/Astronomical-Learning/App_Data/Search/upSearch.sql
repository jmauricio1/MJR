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
    CONSTRAINT [PK_dbo.SitePages] PRIMARY KEY CLUSTERED ([Id] ASC)
);
GO
