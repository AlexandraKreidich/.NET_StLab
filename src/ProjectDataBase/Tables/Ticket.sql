CREATE TABLE [dbo].[Ticket]
(
    [Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    [PriceId] INT UNIQUE NOT NULL,
    [UserId] INT NOT NULL,
    [TicketStatusId] INT NOT NULL,
    [CreatedAt] DATETIMEOFFSET NOT NULL,
    FOREIGN KEY (UserId) REFERENCES [dbo].[User](Id),
    FOREIGN KEY (PriceId) REFERENCES [dbo].[Price](Id) ON DELETE CASCADE,
    FOREIGN KEY (TicketStatusId) REFERENCES [dbo].[TicketStatus](Id)
)