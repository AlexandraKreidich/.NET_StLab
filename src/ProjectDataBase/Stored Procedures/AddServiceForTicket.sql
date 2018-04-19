CREATE PROCEDURE [dbo].[AddServiceForTicket]
    @TicketId INT,
    @ServiceId INT,
    @Amount INT
AS
    INSERT INTO [dbo].TicketService (TicketId, ServiceId, Amount)
    VALUES
    (
        @TicketId,
        @ServiceId,
        @Amount
    )