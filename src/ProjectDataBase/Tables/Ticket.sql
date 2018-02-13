﻿CREATE TABLE [dbo].[Ticket]
(
    [Id] INT NOT NULL PRIMARY KEY IDENTITY,
    [PlaceId] INT NOT NULL,
    [UserId] INT NOT NULL,
    [TicketStatusId] INT NOT NULL,
    FOREIGN KEY (UserId) REFERENCES [dbo].[User](Id),
    FOREIGN KEY (PlaceId) REFERENCES [dbo].[Place](Id),
    FOREIGN KEY (TicketStatusId) REFERENCES [dbo].[TicketStatus](Id)
)