CREATE PROCEDURE [dbo].[GetPlacesForSession]
    @HallId int,
    @SessionId int
AS
    DECLARE 
        @DateNow datetimeoffset,
        @Interval int = 15
    SET @DateNow = CONVERT(datetimeoffset, SYSDATETIMEOFFSET())
    SELECT DISTINCT
        p.Id,
        p.HallId,
        pt.Name AS Type,
        pt.Id AS TypeId,
        p.PlaceNumber,
        p.RowNumber,
        pr.Price,
        pr.Id as PriceId,
        ISNULL(ts.Name, 'Free') as  PlaceStatus
    FROM [Place] p
        INNER JOIN PlaceType pt
            ON p.PlaceTypeId = pt.Id
        INNER JOIN Price pr
            ON p.Id = pr.PlaceId
        LEFT JOIN Ticket t
            ON ((t.PriceId = pr.Id) AND (DATEDIFF(minute, t.CreatedAt, @DateNow) < @Interval))
        LEFT JOIN TicketStatus ts
            ON t.TicketStatusId = ts.Id
    WHERE HallId = @HallId AND pr.SessionId = @SessionId