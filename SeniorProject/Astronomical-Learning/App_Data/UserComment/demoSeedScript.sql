INSERT INTO [dbo].[UserComment] (Username, PostDate, PageFrom, AcceptState, Comment, ReportCount)
	VALUES ('TestUser1', '1/1/2020', '/SolarSystem/Sun_Information', 1, 'This is a good comment', 0),
		   ('TestUser4Reports', '1/1/2020', '/SolarSystem/Sun_Information', 1, 'This is a malicious content', 4);