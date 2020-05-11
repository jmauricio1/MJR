CREATE TABLE [dbo].[PlanetFilters]
(
    [Id]                INT IDENTITY(1, 1)      NOT NULL,
    [PlanetName]        NVARCHAR(64)            NOT NULL,
    [Moon0to5]          BIT                     NULL,
    [Moon6to15]         BIT                     NULL,
    [Moon16to30]        BIT                     NULL,
    [Moon30plus]        BIT                     NULL,
    [TypeTerra]         BIT                     NULL,
    [TypeGas]           BIT                     NULL,
    [TypeIce]           BIT                     NULL,
    [SizeSmaller]       BIT                     NULL,
    [SizeEarthlike]     BIT                     NULL,
    [SizeLarger]        BIT                     NULL,
    [SizeMassive]       BIT                     NULL,
    [Orbit1Year]        BIT                     NULL,
    [Orbit1to10Year]    BIT                     NULL,
    [Orbit11to30Year]   BIT                     NULL,
    [Orbit30plusYear]   BIT                     NULL,
    [WaterIce]          BIT                     NULL,
    [WaterLiquid]       BIT                     NULL,
    [WaterVapor]        BIT                     NULL,
    [HumanContactTrue]  BIT                     NULL,
    [HumanContactFalse] BIT                     NULL,
    [AtmoNone]          BIT                     NULL,
    [AtmoThin]          BIT                     NULL,
    [AtmoModerate]      BIT                     NULL,
    [AtmoHeavy]         BIT                     NULL,
    [AtmoIcy]           BIT                     NULL,
    [RingsTrue]         BIT                     NULL,
    [RingsFalse]        BIT                     NULL
    
    CONSTRAINT [PK_dbo.PlanetFilters] PRIMARY KEY CLUSTERED ([ID] ASC)
);
