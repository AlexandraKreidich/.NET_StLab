CREATE PROCEDURE [dbo].[GetServicesForTicketId]
    @TicketId int
AS
    SELECT
        s.Id,
        s.Name,
        s.Price
    FROM Service s
        JOIN TicketService ts ON ts.ServiceId = s.Id
    WHERE ts.TicketId = @TicketId