CREATE PROCEDURE [dbo].[GetCinemas]
AS
    SELECT
        Cinema.Id,
        Cinema.Name,
        Cinema.City,
            (SELECT COUNT(CinemaId)
            FROM Hall
            WHERE CinemaId = Cinema.Id) AS
        HallsNumber
    FROM Cinema