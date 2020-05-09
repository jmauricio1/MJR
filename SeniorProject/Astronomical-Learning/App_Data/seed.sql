INSERT INTO [dbo].[AvatarPaths] ([AvatarName],[Path]) VALUES
	('Rocket', '/Images/Profile/avatars/rocket-a.png'),
	('Astronaut', '/Images/Profile/avatars/astronaut-a.png'),
	('Comet', '/Images/Profile/avatars/comet-a.png'),
	('Constellations', '/Images/Profile/avatars/const-a.png'),
	('Moon', '/Images/Profile/avatars/moon-a.png'),
	('Saturn', '/Images/Profile/avatars/saturn-a.png'),
	('Star', '/Images/Profile/avatars/star-a.png'),
	('None', '/Images/Profile/avatars/default-profile.png');

INSERT INTO [dbo].[UserComment] (Username, PostDate, PageFrom, AcceptState, Comment, ReportCount)
	VALUES ('TestUser1', '1/1/2020', '/SolarSystem/Sun_Information', 1, 'This is a good comment', 0),
		   ('TestUser4Reports', '1/1/2020', '/SolarSystem/Sun_Information', 1, 'This is a malicious content', 4);

-- #######################################
-- #             Search Tables         #
-- #######################################



INSERT INTO [dbo].[SearchKeywords] (Name)
VALUES  ('Suns'),
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


INSERT INTO [dbo].[SitePages] (Name, Link, Description)
VALUES ('The Sun','SolarSystem/Sun_Information','Learn more about the ball in the center of the Solar System that lights up all of our days.'),
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

-- #######################################
-- #             Search Tables         #
-- #######################################

INSERT INTO [dbo].[AspNetRoles] (Id,Name)
VALUES  (1,'User'),
		(2,'Admin'),
		(3,'SuperAdmin')
;
GO

-- #######################################
-- #             Fact of the Day Tables         #
-- #######################################

-- ############# AspNetRoles #############
INSERT INTO [dbo].[FactOfTheDay] (Text, Source)
VALUES ('Space is completly silent.', 'https://theplanets.org/space-facts/'),
		('The footsprints on the moon will be there for 100 million years.', 'https://theplanets.org/space-facts/'),
		('A Nasa spacesuit costs $12,000,000.','https://theplanets.org/space-facts/'),
		('The temperature of space is around -270.55°C or -454.81°F.','https://space-facts.com/'),
		('The universe is about 13.8 billion years old.','https://space-facts.com/'),
		('The space between galaxies has an average of one atom per cubic meter.','https://space-facts.com/'),
		('An asteroid about the size of a car enters the atmosphere of Earth about once a year but quickly burns up in the atmosphere.','https://www.natgeokids.com/nz/discover/science/space/ten-facts-about-space/'),
		('It would take you 500 years to fly to Pluto on a plane.','https://www.natgeokids.com/nz/discover/science/space/ten-facts-about-space/'),
		('More energy from the Sun hits the Earth every hour than all of Earth uses in a year.','https://mashable.com/article/sun-stars-space-facts/'),
		('If the sun was the size of an average front door, the Earth would be the size of a nickel.','https://www.planetsforkids.org/other/cool-space-facts.html')
		;
GO
