-- #######################################
-- #             Projects Tables         #
-- #######################################

CREATE TABLE [dbo].[Projects]
(
    [Id]   INT IDENTITY (1,1) NOT NULL,
    [UserName] NVARCHAR (256) NOT NULL,
    [Title] NVARCHAR (256) NOT NULL,
    [Description] NVARCHAR (1000) NOT NULL,
    [PostDate] DATE NOT NULL,
    [AcceptState] BIT  NOT NULL,
    CONSTRAINT [PK_dbo.Projects] PRIMARY KEY CLUSTERED ([Id] ASC)
);
GO
