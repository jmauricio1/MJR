DROP TABLE [dbo].[AspNetUserRoles];
DROP TABLE [dbo].[AspNetUserClaims];
DROP TABLE [dbo].[AspNetUserLogins];
DROP TABLE [dbo].[AspNetUsers];
DROP TABLE [dbo].[AspNetRoles];
DROP TABLE [dbo].[AvatarPaths];
DROP TABLE [dbo].[UserComment];
ALTER TABLE [dbo].[LocationDistance] DROP CONSTRAINT [FK_dbo.LocationOne_Distance];
ALTER TABLE [dbo].[LocationDistance] DROP CONSTRAINT [FK_dbo.LocationTwo_Distance];
ALTER TABLE [dbo].[LocationDistance] DROP CONSTRAINT [FK_dbo.Distance_Location];
DROP TABLE [dbo].[LocationDistance];
DROP TABLE [dbo].[Distances];
DROP TABLE [dbo].[Locations];
DROP TABLE [dbo].[SearchKeywords];
DROP TABLE [dbo].[KeywordRelations];
DROP TABLE [dbo].[SitePages];
DROP TABLE [dbo].[FactOfTheDay];

