CREATE TABLE [dbo].[TicketService]
(
    [TicketId] INT NOT NULL,
    [ServiceId] INT NOT NULL,
    FOREIGN KEY (ServiceId) REFERENCES [dbo].[Service](Id),
    FOREIGN KEY (TicketId) REFERENCES [dbo].[Session](Id)
)
