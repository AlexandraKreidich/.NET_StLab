CREATE TABLE [dbo].[Ticket]
(
    [Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    [PlaceId] INT NOT NULL,
    [UserId] INT NOT NULL,
    [TicketStatusId] INT NOT NULL,
    [CreatedAt] DATETIMEOFFSET NOT NULL,
    [Price] DECIMAL(10,4) NOT NULL,
    [Services] NVARCHAR(100) NULL ,
    FOREIGN KEY (UserId) REFERENCES [dbo].[User](Id),
    FOREIGN KEY (PlaceId) REFERENCES [dbo].[Place](Id),
    FOREIGN KEY (TicketStatusId) REFERENCES [dbo].[TicketStatus](Id)
)