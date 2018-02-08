CREATE TABLE [dbo].[Hall]
(
	[id] INT NOT NULL PRIMARY KEY IDENTITY,
    [cinemaId] INT NOT NULL,
	[name] VARCHAR(MAX) NOT NULL, 
    FOREIGN KEY (cinemaId) REFERENCES [dbo].[Cinema](id)
)
