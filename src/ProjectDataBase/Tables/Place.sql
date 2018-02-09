CREATE TABLE [dbo].[Place]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[RowNumber] INT NOT NULL,
	[PlaceNumber] INT NOT NULL,
	[PriceId] INT NOT NULL,
	[HallId] INT NOT NULL,
	FOREIGN KEY (PriceId) REFERENCES [dbo].[Price](Id),
	FOREIGN KEY (HallId) REFERENCES [dbo].[Hall](Id)
)