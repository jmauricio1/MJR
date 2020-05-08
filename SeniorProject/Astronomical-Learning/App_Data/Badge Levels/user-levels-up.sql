CREATE TABLE [dbo].[UserLevels]
(
	[ID]		INT IDENTITY (1, 1)		NOT NULL,
	[LevelName] NVARCHAR(64)			NOT NULL,
	CONSTRAINT [PK_dbo.UserLevels] PRIMARY KEY CLUSTERED ([ID] ASC)
);

INSERT INTO [dbo].[UserLevels] ([LevelName]) VALUES
	('Star Gazer'),
	('Astronaut in Training'),
	('Astronaut'),
	('Star Charter'),
	('Orbit Breaker'),
	('Space Walker'),
	('Shooting Star'),
	('Superstar'),
	('Supernova'),
	('Celestial Being');

ALTER TABLE [dbo].[UserLevels] ADD
	[BadgePath]		NVARCHAR(64)	NULL;

ALTER TABLE [dbo].[AspNetUsers] ADD
	[LevelID]		INT				NULL;

ALTER TABLE [dbo].[AspNetUsers] ADD
	CONSTRAINT [FK_dbo.AspNetUsers_dbo.UserLevels_ID] FOREIGN KEY ([LevelID]) REFERENCES [dbo].[UserLevels]([ID]); 
