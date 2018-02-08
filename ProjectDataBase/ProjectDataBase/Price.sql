CREATE TABLE [dbo].[Price]
(
	[id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [placeTypeId] INT NOT NULL,
    [sessionId] INT NOT NULL,
	[price] INT NOT NULL,
	FOREIGN KEY (sessionId) REFERENCES [dbo].[Session](id),
	FOREIGN KEY (placeTypeId) REFERENCES [dbo].[PlaceType](id)
)
