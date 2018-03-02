CREATE PROCEDURE [dbo].[GetHallScheme]
    @HallId INT
AS
    SELECT *
    FROM HallScheme
    WHERE HallId = @HallId
