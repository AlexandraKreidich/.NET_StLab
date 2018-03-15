CREATE PROCEDURE [dbo].[GetTicketsForUser]
    @UserId int
AS
    SELECT
        Ticket.Id as TicketId,
        Film.Name as FilmName,
        Price.PlaceId,
        Place.PlaceNumber,
        Place.RowNumber,
        PlaceType.Name as PlaceType,
        Hall.Name as HallName,
        Cinema.Name AS CinemaName,
        TicketStatus.Name AS TicketStatus,
        Ticket.CreatedAt,
        Price.Price as SessionPrice
    FROM
        Ticket
            JOIN Price ON Price.Id = Ticket.PriceId
            JOIN Session ON Session.Id = Price.SessionId
            JOIN Film ON Film.Id = Session.FilmId
            JOIN Place ON Place.Id = Price.PlaceId
            JOIN PlaceType ON PlaceType.Id = Place.PlaceTypeId
            JOIN Hall ON Session.HallId = Hall.Id
            JOIN Cinema ON Cinema.Id = Hall.CinemaId
            JOIN TicketStatus ON Ticket.TicketStatusId = TicketStatus.Id
    WHERE
        Ticket.UserId = @UserId