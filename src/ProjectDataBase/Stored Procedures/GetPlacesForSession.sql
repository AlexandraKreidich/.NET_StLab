CREATE PROCEDURE [dbo].[GetPlacesForSession]
    @HallId int,
    @SessionId int
AS
    SELECT DISTINCT
        p.Id,
        p.HallId,
        pt.Name AS Type,
        pt.Id AS TypeId,
        p.PlaceNumber,
        p.RowNumber,
        pr.Price,
        ISNULL(ts.Name, 'Free') as  PlaceStatus
    FROM [Place] p
        INNER JOIN PlaceType pt
            ON p.PlaceTypeId = pt.Id
        INNER JOIN Price pr
            ON p.Id = pr.PlaceId
        LEFT JOIN Ticket t
			ON t.PriceId = pr.Id
		LEFT JOIN TicketStatus ts
			ON t.TicketStatusId = ts.Id
    WHERE HallId = @HallId AND pr.SessionId = @SessionId