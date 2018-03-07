CREATE PROCEDURE [dbo].[FilterFilms]
    @City nvarchar(50),
    @Cinema nvarchar(50),
    @Film nvarchar(50),
    @Date datetime,
    @FreePlaces int
AS
    SET @date = CONVERT(DATETIME, @Date, 120);
    SELECT DISTINCT
        Session.Id,
        Session.HallId,
        Session.FilmId,
        Film.Name as FilmName,
        Cinema.Name as CinemaName,
        Cinema.City as CinemaCity,
        Session.Date as SessionDate
    FROM Hall
        JOIN Cinema ON hall.CinemaId = Cinema.Id
        JOIN Session ON Session.HallId = Hall.Id
        JOIN Film ON Session.FilmId = Film.Id
        JOIN Place ON Hall.Id = Place.HallId
        JOIN Ticket ON Ticket.PlaceId = Place.Id
    WHERE (Cinema.Name = @Cinema) 
        AND (Cinema.City = @City)
        AND (Session.Date >= @date
            AND Session.Date < DATEADD(d, 1, @date))
        AND (Film.Name = @Film)
        AND ((select count(Id) from Ticket) > @FreePlaces)