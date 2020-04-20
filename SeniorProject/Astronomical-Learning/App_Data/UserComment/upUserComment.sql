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

INSERT INTO [dbo].[UserComment] (Username, PostDate, PageFrom, AcceptState, Comment, ReportCount)
VALUES ('TestUser', 'January 1, 2020', '/SolarSystem/Sun_Information', 1, 'This is a test comment. There are many test comments like it, but this one is mine. I love my test my comment and my test comment loves me. We are happy together, as happy as can be.', 0),
('TestUser2', 'December 25, 1969', '/SolarSystem/Sun_Information', 1, 'This is another test comment.', 0);