CREATE PROCEDURE [dbo].[GetServicesForTicketId]
    @TicketId int
AS
    SELECT 
        Service.Id,
        Service.Name,
        Service.Price
    FROM Service
        JOIN TicketService ON TicketService.ServiceId = Service.Id
WHERE TicketService.TicketId = @TicketId