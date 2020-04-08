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
