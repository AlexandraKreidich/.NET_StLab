CREATE PROCEDURE [dbo].[GetAllSessionsForFilm]
    @FilmId int
AS
    SELECT
        Session.Id,
        Session.HallId,
        Session.FilmId,
        Session.Date,
        Cinema.Name as CinemaName,
        Cinema.City as CinemaCity
    FROM Hall
        JOIN Cinema ON hall.CinemaId=Cinema.Id 
        JOIN Session ON Session.HallId=Hall.Id
    WHERE Session.FilmId = @FilmId