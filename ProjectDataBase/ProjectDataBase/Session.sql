CREATE TABLE [dbo].[Session]
(
	[id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [filmId] INT NOT NULL, 
    [hallId] INT NOT NULL, 
    [date] DATE NOT NULL, 
    [time] TIME NOT NULL,
	FOREIGN KEY (filmId) REFERENCES [dbo].[Film](id),
	FOREIGN KEY (hallId) REFERENCES [dbo].[Hall](id)
)
