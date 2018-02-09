CREATE TABLE [dbo].[Ticket]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[PlaceId] INT NOT NULL,
	[UserId] INT NOT NULL,
	[StatusId] INT NOT NULL,
	FOREIGN KEY (UserId) REFERENCES [dbo].[User](Id),
	FOREIGN KEY (PlaceId) REFERENCES [dbo].[Place](Id),
	FOREIGN KEY (StatusId) REFERENCES [dbo].[Status](Id)
)