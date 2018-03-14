CREATE PROCEDURE [dbo].[GetSessionById]
    @Id int
AS
    SELECT DISTINCT
        Session.Id,
        Session.HallId,
        Hall.Name as HallName,
        Session.FilmId,
        Film.Name as FilmName,
        Cinema.Name as CinemaName,
        Cinema.City as CinemaCity,
        Session.Date as SessionDate
    FROM Session
        JOIN Hall ON Hall.Id = Session.HallId
        JOIN Cinema ON Cinema.Id = Hall.CinemaId
        JOIN Film ON Film.Id = Session.FilmId
    WHERE Session.Id = @Id