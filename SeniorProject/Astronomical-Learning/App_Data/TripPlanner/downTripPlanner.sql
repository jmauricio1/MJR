ALTER TABLE [dbo].[LocationDistance] DROP CONSTRAINT [FK_dbo.LocationOne_Distance];
ALTER TABLE [dbo].[LocationDistance] DROP CONSTRAINT [FK_dbo.LocationTwo_Distance];
ALTER TABLE [dbo].[LocationDistance] DROP CONSTRAINT [FK_dbo.Distance_Location];
DROP TABLE [dbo].[LocationDistance];

DROP TABLE [dbo].[Distances];
DROP TABLE [dbo].[Locations];

