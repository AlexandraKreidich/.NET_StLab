CREATE PROCEDURE [dbo].[AddServiceForTicket]
    @TicketId int,
    @ServiceId INT,
    @Amount int
AS
    INSERT INTO [dbo].TicketService (TicketId, ServiceId, Amount)
    VALUES
    (
        @TicketId,
        @ServiceId,
        @Amount
    )
