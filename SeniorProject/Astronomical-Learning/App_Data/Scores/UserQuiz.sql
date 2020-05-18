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

INSERT INTO [dbo].[Quizzes] ([Name]) VALUES
	('Our Solar System');

ALTER TABLE [dbo].[AspNetUsers] ADD
	[AccountScore]	INT  NULL;