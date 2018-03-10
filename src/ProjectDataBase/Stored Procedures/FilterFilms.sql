CREATE PROCEDURE [dbo].[FilterFilms]
    @City nvarchar(50) = null,
    @Cinema nvarchar(50) = null,
    @Film nvarchar(50) = null,
    @Date datetime = null,
    @FreePlaces int = null,
    @d datetime
AS
    SET @d = CONVERT(DATETIME, @Date, 120);
    SELECT DISTINCT
        Session.Id,
        Session.HallId,
        Hall.Name,
        Session.FilmId,
        Film.Name as FilmName,
        Cinema.Name as CinemaName,
        Cinema.City as CinemaCity,
        Session.Date as SessionDate
    FROM Hall
        JOIN Cinema ON hall.CinemaId = Cinema.Id
        JOIN Session s ON s.HallId = Hall.Id
        JOIN Place p ON Hall.Id = p.HallId,
        Film
        JOIN Session ON Session.FilmId = Film.Id,
        Ticket
        JOIN Place ON Ticket.PlaceId = Place.Id
    WHERE (@Cinema is null 
            or Cinema.Name = @Cinema) 
        AND (@City is null 
            or Cinema.City = @City)
        AND (@date is null 
            or (Session.Date >= @date
                AND Session.Date < DATEADD(d, 1, @d)))
        AND (@Film is null 
            or Film.Name = @Film)
        AND (@FreePlaces is null 
            or (select count(Id) from Ticket) > @FreePlaces)