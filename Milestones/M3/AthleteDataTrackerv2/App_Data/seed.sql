INSERT INTO [dbo].[Athletes]([FName], [LName], [Gender]) VALUES
	('Jonathan', 'Doe', 'Male'),
	('Emily', 'Atkinson', 'Female'),
	('Anthony', 'Rivers', 'Male');

INSERT INTO [dbo].[Locations] ([Name]) VALUES
	('Salem Aquatic Center'),
	('Pacific Swim Lanes');

INSERT INTO [dbo].[Events] ([EventName]) VALUES
	('50 Meter Backstroke'),
	('100 Meter Backstroke'),
	('200 Meter Backstroke'),
	('50 Meter Breaststroke'),
	('100 Meter Breaststroke'),
	('200 Meter Breaststroke'),
	('50 Meter Butterfly'),
	('100 Meter Butterfly'),
	('200 Meter Butterfly'),
	('50 Meter Freestyle'),
	('100 Meter Freestyle'),
	('200 Meter Freestyle'),
	('400 Meter Freestyle'),
	('800 Meter Freestyle'),
	('1500 Meter Freestyle'),
	('4 x 100 Meter Freestyle'),
	('4 x 200 Meter Freestyle'),
	('100 Meter Individual Medley'),
	('200 Meter Individual Medley'),
	('400 Meter Individual Medley'),
	('4 x 100 Meter Medley Relay');

INSERT INTO [dbo].[Coaches] ([FName], [LName]) VALUES
	('Rick', 'Astley'),
	('Michelle', 'Phillips');

INSERT INTO [dbo].[Teams] ([SchoolName], [CID]) VALUES
	('Mid-Oregon High School', '1'),
	('North-Oregon High School', '2');

INSERT INTO [dbo].[TeamAthletes] ([TID], [AID]) VALUES
	('1', '1'),
	('1', '2'),
	('2', '3');

INSERT INTO [dbo].[AthleteEvents] ([AID], [EID]) VALUES
	('1', '1'),
	('1', '4'),
	('1', '7'),
	('2', '2'),
	('2', '5'),
	('2', '8'),
	('3', '3'),
	('3', '6'),
	('3', '9');

INSERT INTO [dbo].[AthleteResults] ([AID], [EID], [EventDate], [LID], [RaceTime]) VALUES
	('1', '1', '05-20-2018', '1', '32.11'),
	('2', '2', '05-20-2018', '1', '67.18'),
	('3', '3', '05-20-2018', '1', '134.56'),
	('1', '4', '04-28-2018', '2', '37.98'),
	('2', '8', '04-28-2018', '2', '77.44'),
	('3', '6', '04-28-2018', '2', '160.23');
