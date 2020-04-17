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