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