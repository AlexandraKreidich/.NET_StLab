CREATE TABLE [dbo].[Film]
(
	[id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [startShowDate] DATE NOT NULL, 
    [endShowDate] DATE NOT NULL, 
	[name] TEXT NOT NULL,
    [description] TEXT NOT NULL
)
