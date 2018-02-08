CREATE TABLE [dbo].[Ticket]
(
	[id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [placeId] INT NOT NULL, 
    [userId] INT NOT NULL, 
    [statusId] INT NOT NULL,
	FOREIGN KEY (userId) REFERENCES [dbo].[User](id),
	FOREIGN KEY (placeId) REFERENCES [dbo].[Place](id),
	FOREIGN KEY (statusId) REFERENCES [dbo].[Status](id)
)
