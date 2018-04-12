CREATE PROCEDURE [dbo].[GetHallById]
    @Id int
AS
    SELECT 
    Hall.Id,
    Hall.CinemaId,
    Hall.Name as HallName,
    Cinema.Name as CinemaName
FROM Hall
    INNER JOIN Cinema ON Hall.CinemaId = Cinema.Id
WHERE Hall.Id = @Id