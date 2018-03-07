CREATE PROCEDURE [dbo].[GetAllSessionsForFilm]
    @FilmId int
AS
    SELECT DISTINCT
        Session.Id,
        Session.HallId,
        Session.FilmId,
        Film.Name as FilmName,
        Cinema.Name as CinemaName,
        Cinema.City as CinemaCity,
        Session.Date as SessionDate
    FROM Hall
        JOIN Cinema ON hall.CinemaId=Cinema.Id
        JOIN Session ON Session.HallId = Hall.Id,
        Film
    WHERE Session.FilmId = @FilmId AND Film.Id = @FilmId