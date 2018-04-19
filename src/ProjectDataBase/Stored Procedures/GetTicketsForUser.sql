CREATE PROCEDURE [dbo].[GetTicketsForUser]
    @UserId int
AS
    DECLARE
        @DateNow datetimeoffset,
        @Interval int
    SET @DateNow = CONVERT(datetimeoffset, SYSDATETIMEOFFSET())
    SET @Interval = 15
    SELECT
        t.Id as TicketId,
        f.Name as FilmName,
        pl.PlaceNumber,
        pl.RowNumber,
        plt.Name as PlaceType,
        plt.Id AS PlaceTypeId,
        h.Name as HallName,
        c.Name AS CinemaName,
        ts.Name AS TicketStatus,
        t.CreatedAt,
        pr.Price as SessionPrice
    FROM
        Ticket t
            JOIN Price pr ON pr.Id = t.PriceId
            JOIN Session s ON s.Id = pr.SessionId
            JOIN Film f ON f.Id = s.FilmId
            JOIN Place pl ON pl.Id = pr.PlaceId
            JOIN PlaceType plt ON plt.Id = pl.PlaceTypeId
            JOIN Hall h ON s.HallId = h.Id
            JOIN Cinema c ON c.Id = h.CinemaId
            JOIN TicketStatus ts ON t.TicketStatusId = ts.Id
    WHERE
        (t.UserId = @UserId) AND ((DATEDIFF(minute, t.CreatedAt, @DateNow) < @Interval) OR
                ((
                    SELECT TicketStatus.Name
                    FROM TicketStatus
                    WHERE t.TicketStatusId = TicketStatus.Id
                ) = 'Paid'))