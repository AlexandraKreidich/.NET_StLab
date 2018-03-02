CREATE PROCEDURE [dbo].[GetPlaces]
    @HallId int
AS
    SELECT
        p.Id,
        p.HallId,
        pt.Name AS Type,
        p.PlaceNumber,
        p.RowNumber
    FROM [Place] p
        INNER JOIN PlaceType pt
            ON p.PlaceTypeId = pt.Id
    WHERE HallId = @HallId