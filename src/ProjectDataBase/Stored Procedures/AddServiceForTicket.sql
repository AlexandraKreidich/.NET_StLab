CREATE PROCEDURE [dbo].[AddServiceForTicket]
    @TicketId int,
    @ServiceId int
AS
    INSERT INTO [dbo].TicketService (TicketId, ServiceId)
    VALUES
    (
        @TicketId,
        @ServiceId
    )
