CREATE PROCEDURE [dbo].[AddServiceForTicket]
    @TicketId INT,
    @ServiceId INT,
    @Amount INT
AS
    IF(
        (SELECT TicketId
        FROM TicketService
        WHERE TicketId = @TicketId) IS NOT NULL
    )
        DELETE FROM TicketService WHERE TicketId = @TicketId

        INSERT INTO [dbo].TicketService (TicketId, ServiceId, Amount)
        VALUES
        (
            @TicketId,
            @ServiceId,
            @Amount
        )
