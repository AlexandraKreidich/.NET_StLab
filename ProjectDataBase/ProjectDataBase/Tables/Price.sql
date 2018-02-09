CREATE TABLE [dbo].[Price]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[PlaceTypeId] INT NOT NULL,
	[SessionId] INT NOT NULL,
	[Price] INT NOT NULL,
	FOREIGN KEY (SessionId) REFERENCES [dbo].[Session](Id),
	FOREIGN KEY (PlaceTypeId) REFERENCES [dbo].[PlaceType](Id)
)