CREATE TABLE [dbo].[ViewData]
(
    [Id]            INT             IDENTITY(1,1)   NOT NULL,
    [PageName]      NVARCHAR        (64)            NOT NULL,
    [ViewCount]     DATE                            NOT NULL

    CONSTRAINT [PK_dbo.ViewData] PRIMARY KEY CLUSTERED ([Id] ASC)
);