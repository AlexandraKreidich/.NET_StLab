CREATE PROCEDURE [dbo].[GetAllSessionsForFilm]
    @FilmId int
AS
    SELECT DISTINCT
        Session.Id,
        Session.HallId,
        Session.FilmId,
        Hall.Name AS HallName,
        Film.Name as FilmName,
        Cinema.Name as CinemaName,
        Cinema.City as CinemaCity,
        Session.Date as SessionDate
    FROM Session
        JOIN Hall ON Hall.Id = Session.HallId
        JOIN Film ON Session.FilmId = Film.Id
        JOIN Cinema ON Hall.CinemaId = Cinema.Id
    WHERE
        Session.FilmId = @FilmId