CREATE TABLE [dbo].[Place]
(
	[id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [rowNumber] INT NOT NULL, 
    [placeNumber] INT NOT NULL, 
    [priceId] INT NOT NULL, 
    [hallId] INT NOT NULL, 
    FOREIGN KEY (priceId) REFERENCES [dbo].[Price](id),
	FOREIGN KEY (hallId) REFERENCES [dbo].[Hall](id)
)
