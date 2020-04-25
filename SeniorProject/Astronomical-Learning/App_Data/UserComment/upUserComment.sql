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