CREATE PROCEDURE [dbo].[GetCinemaById]
    @Id int
AS
    SELECT
        Cinema.Name,
        Cinema.City,
            (SELECT COUNT(CinemaId)
            FROM Hall
            WHERE CinemaId = @Id) AS
        HallsNumber
    FROM Cinema
    WHERE Cinema.Id = @Id