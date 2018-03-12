CREATE TABLE [dbo].[Price]
(
    [Id] INT NOT NULL PRIMARY KEY IDENTITY (1,1),
    [SessionId] INT NOT NULL,
    [PlaceId] INT NOT NULL,
    [Price] MONEY NOT NULL,
    [SessionDate] DATETIMEOFFSET NOT NULL,
    FOREIGN KEY (SessionId) REFERENCES [dbo].[Session](Id) ON DELETE CASCADE,
    FOREIGN KEY (PlaceId) REFERENCES [dbo].[Place](Id)
)