CREATE PROCEDURE [dbo].[PayForTicket]
    @TicketStatus NVARCHAR(50),
    @TicketId INT
AS
    UPDATE [dbo].Ticket
    SET TicketStatusId =
        (
            SELECT Id
            FROM TicketStatus
            WHERE TicketStatus.Name = @TicketStatus
        )
    WHERE Id = @TicketId
    SELECT SCOPE_IDENTITY();