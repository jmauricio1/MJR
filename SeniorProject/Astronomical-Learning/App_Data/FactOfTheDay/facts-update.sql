ALTER TABLE [dbo].[FactOfTheDay] ADD
	[AdminUsername] NVARCHAR(128) NULL,
	[DateSubmitted]	DATETIME	  NULL,
	[DisplayCount]  INT			  NULL;

ALTER TABLE [dbo].[FactOfTheDay] ADD
	[LastDisplayed] DATETIME	NULL;

ALTER TABLE [dbo].[FactOfTheDay] DROP
	COLUMN [DateSubmitted],
	[LastDisplayed];

ALTER TABLE [dbo].[FactOfTheDay] ADD
	[DateSubmitted]	DATETIME2	  NULL,
	[LastDisplayed] DATETIME2	NULL;