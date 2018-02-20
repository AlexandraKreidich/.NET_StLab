CREATE TABLE [dbo].[Price]
(
    [Id] INT NOT NULL PRIMARY KEY IDENTITY (1,1),
    [SessionId] INT NOT NULL,
    [PlaceId] INT NOT NULL,
    [Price] DECIMAL(10,4) NOT NULL,
    FOREIGN KEY (SessionId) REFERENCES [dbo].[Session](Id),
    FOREIGN KEY (PlaceId) REFERENCES [dbo].[Place](Id)
)