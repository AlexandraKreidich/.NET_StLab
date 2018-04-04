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
        Film.Id,
        Film.Name,
        Film.Description,
        Film.StartRentDate,
        Film.EndRentDate
    FROM Film
        JOIN Session ON Film.Id = Session.FilmId
        JOIN Hall ON Hall.Id = Session.HallId
        JOIN Cinema ON Cinema.Id = Hall.CinemaId
    WHERE (@Cinema is null
            or Cinema.Name LIKE '%' + @Cinema + '%')
        AND (@City is null
            or Cinema.City LIKE '%' + @City + '%')
        AND (@date is null
            or (Session.Date >= @date
                AND Session.Date < DATEADD(d, 1, @d)))
        AND (@Film is null
            or Film.Name LIKE '%' + @Film + '%')
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
            ) >= @FreePlaces)