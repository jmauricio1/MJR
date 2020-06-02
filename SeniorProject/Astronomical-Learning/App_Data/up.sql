-- #######################################
--  Astronomical Learning Databse Upscript
-- #######################################

-- ############# AspNetRoles #############
CREATE TABLE [dbo].[AvatarPaths]
(
    [ID]            INT IDENTITY(1, 1)  NOT NULL,
    [AvatarName]    NVARCHAR(64)        NOT NULL,
    [Path]          NVARCHAR(128)       NOT NULL,
    CONSTRAINT [PK_dbo.AvatarPaths] PRIMARY KEY CLUSTERED ([ID] ASC)
);

CREATE TABLE [dbo].[AspNetRoles]
(
    [Id]   NVARCHAR (128) NOT NULL,
    [Name] NVARCHAR (256) NOT NULL,
    CONSTRAINT [PK_dbo.AspNetRoles] PRIMARY KEY CLUSTERED ([Id] ASC)
);
GO
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex]
    ON [dbo].[AspNetRoles]([Name] ASC);

CREATE TABLE [dbo].[UserLevels]
(
	[ID]		INT IDENTITY (1, 1)		NOT NULL,
	[LevelName] NVARCHAR(64)			NOT NULL,
    [BadgePath] NVARCHAR(64)	        NULL
	CONSTRAINT [PK_dbo.UserLevels] PRIMARY KEY CLUSTERED ([ID] ASC)
);

-- ############# AspNetUsers #############
CREATE TABLE [dbo].[AspNetUsers]
(
    [Id]                   NVARCHAR (128) NOT NULL,
    [FirstName]            NVARCHAR (128) NOT NULL,
    [LastName]             NVARCHAR (128) NOT NULL,
    [UserName]             NVARCHAR (256) NOT NULL,
    [StateProvince]        NVARCHAR (256) NOT NULL,
    [Country]              NVARCHAR (256) NOT NULL,
    [Email]                NVARCHAR (256) NULL,
    [EmailConfirmed]       BIT            NOT NULL,
    [PasswordHash]         NVARCHAR (MAX) NULL,
    [SecurityStamp]        NVARCHAR (MAX) NULL,
    [PhoneNumber]          NVARCHAR (MAX) NULL,
    [PhoneNumberConfirmed] BIT            NOT NULL,
    [TwoFactorEnabled]     BIT            NOT NULL,
    [LockoutEndDateUtc]    DATETIME       NULL,
    [LockoutEnabled]       BIT            NOT NULL,
    [AccessFailedCount]    INT            NOT NULL,
    [Bio]                  NVARCHAR(256)  NULL,
    [AID]                  INT            NOT NULL,
    [AccountScore]	       INT            NULL,
    [LevelID]		       INT		      NULL,
    CONSTRAINT [PK_dbo.AspNetUsers] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.AspNetUsers_dbo.AvatarPaths_ID] FOREIGN KEY ([AID]) REFERENCES [dbo].[AvatarPaths]([ID]),
    CONSTRAINT [FK_dbo.AspNetUsers_dbo.UserLevels_ID] FOREIGN KEY ([LevelID]) REFERENCES [dbo].[UserLevels]([ID])
);
GO
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[AspNetUsers]([UserName] ASC);

-- ############# AspNetUserClaims #############
CREATE TABLE [dbo].[AspNetUserClaims]
(
    [Id]         INT            IDENTITY (1, 1) NOT NULL,
    [UserId]     NVARCHAR (128) NOT NULL,
    [ClaimType]  NVARCHAR (MAX) NULL,
    [ClaimValue] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_dbo.AspNetUserClaims] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[AspNetUsers] ([Id]) ON DELETE CASCADE
);
GO
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserClaims]([UserId] ASC);

-- ############# AspNetUserLogins #############
CREATE TABLE [dbo].[AspNetUserLogins]
(
    [LoginProvider] NVARCHAR (128) NOT NULL,
    [ProviderKey]   NVARCHAR (128) NOT NULL,
    [UserId]        NVARCHAR (128) NOT NULL,
    CONSTRAINT [PK_dbo.AspNetUserLogins] PRIMARY KEY CLUSTERED ([LoginProvider] ASC, [ProviderKey] ASC, [UserId] ASC),
    CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[AspNetUsers] ([Id]) ON DELETE CASCADE
);
GO
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserLogins]([UserId] ASC);

-- ############# AspNetUserRoles #############
CREATE TABLE [dbo].[AspNetUserRoles]
(
    [UserId] NVARCHAR (128) NOT NULL,
    [RoleId] NVARCHAR (128) NOT NULL,
    CONSTRAINT [PK_dbo.AspNetUserRoles] PRIMARY KEY CLUSTERED ([UserId] ASC, [RoleId] ASC),
    CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [dbo].[AspNetRoles] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[AspNetUsers] ([Id]) ON DELETE CASCADE
);
GO
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserRoles]([UserId] ASC);
GO
CREATE NONCLUSTERED INDEX [IX_RoleId] ON [dbo].[AspNetUserRoles]([RoleId] ASC);

CREATE TABLE [dbo].[ViewData]
(
    [Id]            INT             IDENTITY(1,1)   NOT NULL,
    [PageName]      NVARCHAR        (64)            NOT NULL,
    [ViewCount]     INT								NOT NULL

    CONSTRAINT [PK_dbo.ViewData] PRIMARY KEY CLUSTERED ([Id] ASC)
);

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

CREATE TABLE [dbo].[SearchKeywords]
(
    [Id]   INT IDENTITY (1,1) NOT NULL,
    [Name] NVARCHAR (256) NOT NULL,
    CONSTRAINT [PK_dbo.SearchKeywords] PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[KeywordRelations]
(
    [Id]   INT IDENTITY (1,1) NOT NULL,
    [KeywordId] INT NOT NULL,
    [PageId] INT NOT NULL,
    CONSTRAINT [PK_dbo.KeywordRelations] PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[SitePages]
(
    [Id]   INT IDENTITY (1,1) NOT NULL,
    [Name] NVARCHAR (256) NOT NULL,
    [Link] NVARCHAR (256) NOT NULL,
    [Description] NVARCHAR (256) NOT NULL,
    CONSTRAINT [PK_dbo.SitePages] PRIMARY KEY CLUSTERED ([Id] ASC)
);
GO

CREATE TABLE [dbo].[Quizzes]
(
	[ID]	INT IDENTITY (1, 1)	NOT NULL,
	[Name]	NVARCHAR(128)		NOT NULL,
	CONSTRAINT [PK_dbo.Quizzes] PRIMARY KEY CLUSTERED ([ID] ASC)
);

CREATE TABLE [dbo].[UserQuizScores] 
(
	[ID]			INT IDENTITY (1, 1) NOT NULL,
	[UserID]		NVARCHAR (128)		NOT NULL,
	[QuizID]		INT					NOT NULL,
	[HighestScore]	INT					NOT NULL,
	CONSTRAINT [PK_dbo.UserQuizScores] PRIMARY KEY CLUSTERED ([ID] ASC),
	CONSTRAINT [FK_dbo.UserQuizScores_dbo.AspNetUsers_Id] FOREIGN KEY ([UserID]) REFERENCES [dbo].[AspNetUsers]([Id]),
	CONSTRAINT [FK_dbo.UserQuizScores_dbo.Quizzes_ID] FOREIGN KEY ([QuizID]) REFERENCES [dbo].[Quizzes] ([ID])
);

CREATE TABLE [dbo].[Projects]
(
    [Id]   INT IDENTITY (1,1) NOT NULL,
    [UserName] NVARCHAR (256) NOT NULL,
    [Title] NVARCHAR (256) NOT NULL,
    [Description] NVARCHAR (1000) NOT NULL,
    [PostDate] DATE NOT NULL,
    [AcceptState] BIT  NOT NULL,
    CONSTRAINT [PK_dbo.Projects] PRIMARY KEY CLUSTERED ([Id] ASC)
);
GO

CREATE TABLE [dbo].[FactOfTheDay]
(
    [Id]   INT IDENTITY (1,1)     NOT NULL,
    [Text] NVARCHAR (256)         NOT NULL,
    [Source] NVARCHAR (256)       NOT NULL,
    [AdminUsername] NVARCHAR(128) NULL,
    [DateSubmitted]	DATETIME2	  NULL,
	[LastDisplayed] DATETIME2	  NULL,
    [DisplayCount]  INT			  NULL
    CONSTRAINT [PK_dbo.FactOfTheDay] PRIMARY KEY CLUSTERED ([Id] ASC)
);
GO

-- #######################################
-- #             Seeding Data In         #
-- #######################################

INSERT INTO [dbo].[AvatarPaths] ([AvatarName],[Path]) VALUES
	('Rocket', '/Images/Profile/avatars/rocket-a.png'),
	('Astronaut', '/Images/Profile/avatars/astronaut-a.png'),
	('Comet', '/Images/Profile/avatars/comet-a.png'),
	('Constellations', '/Images/Profile/avatars/const-a.png'),
	('Moon', '/Images/Profile/avatars/moon-a.png'),
	('Saturn', '/Images/Profile/avatars/saturn-a.png'),
	('Star', '/Images/Profile/avatars/star-a.png'),
	('None', '/Images/Profile/avatars/default-profile.png');


INSERT INTO [dbo].[ViewData] (PageName, ViewCount) VALUES 
    ('Sun', 1), 
    ('Moon', 1), 
    ('Planets', 1), 
    ('Mars', 1), 
    ('SpaceDebris', 1),
    ('MilkyWay', 1), 
    ('Andromeda', 1), 
    ('Stars', 1);

INSERT INTO [dbo].[Locations] (LocationName) VALUES
	('Sun'), 
    ('Mercury'), 
    ('Venus'), 
    ('Earth'), 
    ('Mars'),
	('Jupiter'), 
    ('Saturn'), 
    ('Uranus'), 
    ('Neptune');

INSERT INTO [dbo].[Distances] (DistanceMiles)
	VALUES
	(35983015), (67237910), (92955807), (141670000), (481773286), (890704144), (1783939400), (2795084800),
	(31248757),	(56974146),	(105651744), (447648234), (849221795), (1749638696), (2760936126), 
	(25724767), (74402987), (416399477), (817973037), (1718388490), (2729685920), 
	(48678219), (390674710), (792248270), (1692662530), (2703959960),
	(342012346), (743604524), (1643982054), (2313267138),
	(401592178), (1301969708), (2313267138),
	(900377530), (1911674960), 
	(1011297430);

INSERT INTO [dbo].[LocationDistance] (LocationOneId, LocationTwoId, DistanceId)
	VALUES
	(1, 2, 1), (2, 1, 1), --Sun / Mercury
	(1, 3, 2), (3, 1, 2), --Sun / Venus
	(1, 4, 3), (4, 1, 3), --Sun / Earth
	(1, 5, 4), (5, 1, 4), --Sun / Mars
	(1, 6, 5), (6, 1, 5), --Sun / Jupiter
	(1, 7, 6), (7, 1, 6), --Sun / Saturn
	(1, 8, 7), (8, 1, 7), --Sun / Uranus
	(1, 9, 8), (9, 1, 8), --Sun / Neptune
	(2, 3, 9), (3, 2, 9), --Mercury / Venus
	(2, 4, 10), (4, 2, 10),  --Mercury / Earth
	(2, 5, 11), (5, 2, 11), --Mercury / Mars
	(2, 6, 12), (6, 2, 12), --Mercury / Jupiter
	(2, 7, 13), (7, 2, 13), --Mercury / Saturn
	(2, 8, 14), (8, 2, 14), --Mercury / Uranus
	(2, 9, 15), (9, 2, 15), --Mercury / neptune
	(3, 4, 16), (4, 3, 16), --Venus / Earth
	(3, 5, 17), (5, 3, 17), --Venus / Mars
	(3, 6, 18), (6, 3, 18), --Venus / Jupiter
	(3, 7, 19), (7, 3, 19), --Venus / Saturn
	(3, 8, 20), (8, 3, 20), --Venus / Uranus
	(3, 9, 21), (9, 3, 21), --Venus / Neptune
	(4, 5, 22), (5, 4, 22), --Earth / Mars
	(4, 6, 23), (6, 4, 23), --Earth / Jupiter
	(4, 7, 24), (7, 4, 24), --Earth / Saturn
	(4, 8, 25), (8, 4, 25), --Earth / Uranus
	(4, 9, 26), (9, 4, 26), --Earth / Neptune
	(5, 6, 27), (6, 5, 27), --Mars / Jupiter
	(5, 7, 28), (7, 5, 28), --Mars / Saturn
	(5, 8, 29), (8, 5, 29), --Mars / Uranus
	(5, 9, 30), (9, 5, 30), --Mars / Neptune
	(6, 7, 31), (7, 6, 31), --Jupiter / Saturn
	(6, 8, 32), (8, 6, 32), --Jupiter / Uranus
	(6, 9, 33), (9, 6, 33), --Jupiter / Neptune
	(7, 8, 34), (8, 7, 34), --Saturn / Uranus
	(7, 9, 35), (9, 7, 35), --Saturn / Neptune
	(8, 9, 36), (9, 8, 36); --Uranus / Neptune

INSERT INTO [dbo].[PlanetFilters] (PlanetName, 
                                   Moon0to5, Moon6to15, Moon16to30, Moon30plus, 
                                   TypeTerra, TypeGas, TypeIce, 
                                   SizeSmaller, SizeEarthlike, SizeLarger, SizeMassive,
                                   Orbit1Year, Orbit1to10Year, Orbit11to30Year, Orbit30plusYear, 
                                   WaterIce, WaterLiquid, WaterVapor,
                                   HumanContactTrue, HumanContactFalse, 
                                   AtmoNone, AtmoThin, AtmoModerate, AtmoHeavy, AtmoIcy, 
                                   RingsTrue, RingsFalse)
	VALUES
    ('Mercury', 
    1, 0, 0, 0,
    1, 0, 0, 
    1, 0, 0, 0, 
    1, 0, 0, 0, 
    1, 0, 0,
    0, 1,
    1, 0, 0, 0, 0,
    0, 1),
    ('Venus',
    1, 0, 0, 0,
    1, 0, 0, 
    0, 1, 0, 0,
    1, 0, 0, 0,
    0, 0, 1,
    1, 0,
    0, 0, 0, 1, 0,
    0, 1),
    ('Earth',
    1, 0, 0, 0,
    1, 0, 0,
    0, 1, 0, 0,
    1, 0, 0, 0,
    1, 1, 1, 
    1, 0,
    0, 0, 1, 0, 0,
    0, 1),
    ('Mars', 
    1, 0, 0, 0,
    1, 0, 0,
    1, 0, 0, 0,
    0, 1, 0, 0,
    1, 0, 1,
    1, 0, 
    0, 1, 0, 0, 0,
    0, 1),
    ('Jupiter',
    0, 0, 0, 1,
    0, 1, 0,
    0, 0, 0, 1,
    0, 0, 1, 0,
    0, 0, 1,
    0, 1, 
    0, 0, 0, 1, 0,
    1, 0),
    ('Saturn',
    0, 0, 0, 1,
    0, 1, 0,
    0, 0, 0, 1,
    0, 0, 1, 0,
    1, 0, 0,
    0, 1,
    0, 0, 0, 1, 0,
    1, 0),
	('Uranus',
    0, 0, 1, 0,
    0, 0, 1,
    0, 0, 1, 0,
    0, 0, 0, 1,
    1, 0, 0,
    0, 1,
    0, 0, 0, 0, 1,
    1, 0
    ),
    ('Neptune',
    0, 1, 0, 0,
    0, 0, 1,
    0, 0, 1, 0,
    0, 0, 0, 1,
    1, 0, 0,
    0, 1,
    0, 0, 0, 0, 1,
    1, 0);

INSERT INTO [dbo].[SearchKeywords] (Name) VALUES  
    ('Suns'),
	('Moons'),
    ('Stars'),
	('Planets'),
    ('SpaceX'),
	('Nasa'),
	('Asteroids'),
	('Meteoroids'),
	('Galaxies'),
	('Galaxy')
;


INSERT INTO [dbo].[SitePages] (Name, Link, Description) VALUES 
    ('The Sun','SolarSystem/Sun_Information','Learn more about the ball in the center of the Solar System that lights up all of our days.'),
	('The Moon','SolarSystem/Moon_Information', 'Learn more about that big white sphere in the night sky.'),
	('Planets','SolarSystem/Our_Planets', 'Learn more about the planets and dwarf planets that are in our solar system.'),
	('Space Debris','SolarSystem/SpaceDebris_Information', ' Learn more about the debris travelling in space, Asteroids, Comets and Meteoroids.'),
	('Mars Research','SolarSystem/Mars_Research', 'Get more details on the planet Mars, a planet with a lot of research going into it.'),
		
	('Milky Way Galaxy','OuterSystem/MilkyWay_Information', 'Learn more about the galaxy in which Earth resides.'),
	('Andromeda Galaxy','OuterSystem/Andromeda_Information', 'Learn more about our closest spiral galactic neighbor.'),
	('Stars','OuterSystem/Stars_Information', 'Learn more about the types of lights in the night sky.'),
		
	('SpaceX Profile','SpaceCompanies/SpaceX', 'Learn more interesting information about SpaceX and its founder.'),
	('SpaceX Missions','SpaceCompanies/SpaceXLaunches', ' Learn more about launches conducted by SpaceX.'),
	('Nasa Profile','SpaceCompanies/Nasa', 'Learn more about NASA as a U.S. federal agency.'),
	('Nasa Missions','SpaceCompanies/NASAMissions', 'Learn more about NASAs major historical missions.'),
		
	('International Space Station','ISS/InternationalSpaceStation', ' Learn more about one of mankinds greatest collaborative engineering feats.'),
	('Space Suits and Flight Suits','SpaceSuits/SpaceAndFlightSuits', 'Learn more about the vital equipment that keeps astronauts safe in space and during space travel.'),
	('Kuiper Belt','SolarSystem/KuiperBelt', ' Learn more about the icy region of space beyond Neptunes orbit.'),
	('interstellar Space','OuterSystem/Interstellar_Space', ' Learn more about space beyond the influence of our Suns magnetic field.'),
	('Star Constellations','OuterSystem/Stars_Constellations', ' Learn more about the star constellations that been seen in our night sky.');


INSERT INTO [dbo].[KeywordRelations] (KeywordId, PageId)
VALUES (1,1),
		(2,2),
		(3,8),
		(3,1),
		(4,3),
		(4,5),
		(5,9),
		(5,10),
		(6,11),
		(6,12),
		(7,4),
		(8,4),
		(9,6),
		(10,6),
		(9,7),
		(10,7);
GO

INSERT INTO [dbo].[Quizzes] ([Name]) VALUES
	('Our Solar System');

INSERT INTO [dbo].[AspNetRoles] (Id,Name) VALUES  
    (1,'User'),
	(2,'Admin'),
	(3,'SuperAdmin');
GO

INSERT INTO [dbo].[FactOfTheDay] (Text, Source, AdminUsername, DateSubmitted, LastDisplayed, DisplayCount) VALUES 
    ('Space is completly silent.', 'https://theplanets.org/space-facts/', 'NONE', '5-5-2020 12:00:00', '5-5-2020 12:00:00', 0),
	('The footsprints on the moon will be there for 100 million years.', 'https://theplanets.org/space-facts/', 'NONE', '5-5-2020 12:00:00', '5-5-2020 12:00:00', 0),
	('A Nasa spacesuit costs $12,000,000.','https://theplanets.org/space-facts/', 'NONE', '5-5-2020 12:00:00', '5-5-2020 12:00:00', 0),
	('The temperature of space is around -270.55°C or -454.81°F.','https://space-facts.com/', 'NONE', '5-5-2020 12:00:00', '5-5-2020 12:00:00', 0),
	('The universe is about 13.8 billion years old.','https://space-facts.com/', 'NONE', '5-5-2020 12:00:00', '5-5-2020 12:00:00', 0),
	('The space between galaxies has an average of one atom per cubic meter.','https://space-facts.com/', 'NONE', '5-5-2020 12:00:00', '5-5-2020 12:00:00', 0),
	('An asteroid about the size of a car enters the atmosphere of Earth about once a year but quickly burns up in the atmosphere.','https://www.natgeokids.com/nz/discover/science/space/ten-facts-about-space/', 'NONE', '5-5-2020 12:00:00', '5-5-2020 12:00:00', 0),
	('It would take you 500 years to fly to Pluto on a plane.','https://www.natgeokids.com/nz/discover/science/space/ten-facts-about-space/', 'NONE', '5-5-2020 12:00:00', '5-5-2020 12:00:00', 0),
	('More energy from the Sun hits the Earth every hour than all of Earth uses in a year.','https://mashable.com/article/sun-stars-space-facts/', 'NONE', '5-5-2020 12:00:00', '5-5-2020 12:00:00', 0),
	('If the sun was the size of an average front door, the Earth would be the size of a nickel.','https://www.planetsforkids.org/other/cool-space-facts.html', 'NONE', '5-5-2020 12:00:00', '5-5-2020 12:00:00', 0);
GO

INSERT INTO [dbo].[UserLevels] ([LevelName], [BadgePath]) VALUES
	('Star Gazer', '/Images/Levels/1.png'),
	('Astronaut in Training', '/Images/Levels/2.png'),
	('Astronaut', '/Images/Levels/3.png'),
	('Star Charter', '/Images/Levels/4.png'),
	('Orbit Breaker', '/Images/Levels/5.JPG'),
	('Space Walker', '/Images/Levels/6.png'),
	('Shooting Star', null),
	('Superstar', '/Images/Levels/8.png'),
	('Supernova', '/Images/Levels/9.png'),
	('Celestial Being', '/Images/Levels/10.png');