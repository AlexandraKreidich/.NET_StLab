CREATE TABLE [dbo].[TicketService]
(
    [TicketId] INT NOT NULL,
    [ServiceId] INT NOT NULL,
    FOREIGN KEY (ServiceId) REFERENCES [dbo].[Service](Id) ON DELETE CASCADE,
    FOREIGN KEY (TicketId) REFERENCES [dbo].[Ticket](Id) ON DELETE CASCADE
)