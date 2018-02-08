CREATE TABLE [dbo].[HallScheme]
(
	[id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [rowNumber] INT NOT NULL, 
    [placesCount] INT NOT NULL, 
    [hallId] INT NOT NULL,
	FOREIGN KEY (hallId) REFERENCES [dbo].[Hall](id)
)