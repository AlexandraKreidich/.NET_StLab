CREATE PROCEDURE [dbo].[GetTicketsForUser]
    @UserId int
AS
    SELECT
    Ticket.Id as TicketId,
    Film.Name as FilmName,
    Price.PlaceId as PlaceId,
    (
        SELECT Place.PlaceNumber
        FROM Place
        WHERE Place.Id = Price.PlaceId
    ) as PlaceNumber,
    (
        SELECT Place.RowNumber
        FROM Place
        WHERE Place.Id = Price.PlaceId
    ) as RowNumber,
    (
        SELECT PlaceType.Name
        FROM PlaceType
        WHERE Place.PlaceTypeId = PlaceType.Id
    ) as PlaceType,
    (
        SELECT Hall.Name
        FROM Hall
        WHERE Session.HallId = Hall.Id
    ) as HallName,
    (
        SELECT Cinema.Name
        FROM Cinema
        WHERE Cinema.Id =
        (
            SELECT Hall.CinemaId
            FROM Hall
            WHERE Session.HallId = Hall.Id
        )
    ) as CinemaName,
    (
        SELECT TicketStatus.Name
        FROM TicketStatus
        WHERE TicketStatus.Id = Ticket.TicketStatusId
    ) as TicketStatus,
    Ticket.CreatedAt,
    Price.Price as SessionPrice
FROM
    Ticket
        JOIN Price ON Price.Id = Ticket.PriceId
        JOIN Session ON Session.Id = Price.SessionId
        JOIN Film ON Film.Id = Session.FilmId
        JOIN Place ON Place.Id = Price.PlaceId
WHERE
    Ticket.UserId = @UserId