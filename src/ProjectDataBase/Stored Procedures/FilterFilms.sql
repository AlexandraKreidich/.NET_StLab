CREATE PROCEDURE [dbo].[FilterFilms]
    @City nvarchar(50) = null,
    @Cinema nvarchar(50) = null,
    @Film nvarchar(50) = null,
    @Date datetime = null,
    @FreePlaces int = null,
    @d datetime = null
AS
    SET @d = CONVERT(DATETIME, @Date, 120);
    SELECT
        Session.Id,
        Session.HallId,
        Hall.Name as HallName,
        Session.FilmId,
        Film.Name as FilmName,
        Cinema.Name as CinemaName,
        Cinema.City as CinemaCity,
        Session.Date as SessionDate
    FROM Session
        JOIN Film ON Film.Id = Session.FilmId
        JOIN Hall ON Hall.Id = Session.HallId
        JOIN Cinema ON Cinema.Id = Hall.CinemaId
    WHERE (@Cinema is null
            or Cinema.Name = @Cinema)
        AND (@City is null
            or Cinema.City = @City)
        AND (@date is null
            or (Session.Date >= @date
                AND Session.Date < DATEADD(d, 1, @d)))
        AND (@Film is null
            or Film.Name = @Film)
        AND (
                (
                (
                    SELECT count(Id)
                    FROM Place
                    WHERE Place.HallId = Session.HallId
                ) -
                (
                    SELECT count(Ticket.Id)
                    FROM Ticket
                        JOIN Price ON Price.SessionId = Session.Id
                    WHERE Ticket.PriceId = Price.Id
                )
            ) > @FreePlaces)