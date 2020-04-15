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


INSERT INTO [dbo].[SitePages] (Name, Link)
VALUES ('The Sun','SolarSystem/Sun_Information'),
		('The Moon','SolarSystem/Moon_Information'),
		('Planets','SolarSystem/Our_Planets'),
		('Space Debris','SolarSystem/SpaceDebris_Information'),
		('Mars Research','SolarSystem/Mars_Research'),
		
		('Milky Way Galaxy','OuterSystem/MilkyWay_Information'),
		('Andromeda Galaxy','OuterSystem/Andromeda_Information'),
		('Stars','OuterSystem/Stars_Information'),
		
		('SpaceX Profile','SpaceCompanies/SpaceX'),
		('SpaceX Missions','SpaceCompanies/SpaceXLaunches'),
		('Nasa Profile','SpaceCompanies/Nasa'),
		('Nasa Missions','SpaceCompanies/NASAMissions'),
		
		('International Space Station','ISS/InternationalSpaceStation'),
		('Space Suits and Flight Suits','SpaceSuits/SpaceAndFlightSuits'),
		('Kuiper Belt','SolarSystem/KuiperBelt'),
		('interstellar Space','OuterSystem/Interstellar_Space'),
		('Star Constellations','OuterSystem/Stars_Constellations');


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