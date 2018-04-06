CREATE PROCEDURE [dbo].[GetPlacesForSession]
    @HallId int,
    @SessionId int
AS
    SELECT DISTINCT
        p.Id,
        p.HallId,
        pt.Name AS Type,
        pt.Id AS TypeId,
        p.PlaceNumber,
        p.RowNumber,
        pr.Price
    FROM [Place] p
        INNER JOIN PlaceType pt
            ON p.PlaceTypeId = pt.Id
        INNER JOIN Price pr
            ON p.Id = pr.PlaceId
    WHERE HallId = @HallId AND pr.SessionId = @SessionId