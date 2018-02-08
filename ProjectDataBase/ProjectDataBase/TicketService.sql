CREATE TABLE [dbo].[TicketService]
(
    [ticketId] INT NOT NULL, 
    [serviceId] INT NOT NULL,
	FOREIGN KEY (serviceId) REFERENCES [dbo].[Service](id),
	FOREIGN KEY (ticketId) REFERENCES [dbo].[Ticket](id)
)
