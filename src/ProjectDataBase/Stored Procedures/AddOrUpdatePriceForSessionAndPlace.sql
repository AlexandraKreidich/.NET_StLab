CREATE PROCEDURE [dbo].[AddOrUpdatePriceForSessionAndPlace]
    @Id INT = 0,
    @SessionId int,
    @PlaceId int,
    @Price money
AS
    MERGE dbo.Price AS target
    USING
        (SELECT @Id, @SessionId, @PlaceId, @Price)
    AS source
        (Id, SessionId, PlaceId, Price)
    ON
        (target.SessionId = source.SessionId)
    AND
        (target.PlaceId = source.PlaceId)
    WHEN MATCHED THEN
        UPDATE SET
            Price = source.Price
    WHEN NOT MATCHED THEN
        INSERT (SessionId, PlaceId, Price)
        VALUES
        (
            source.SessionId,
            source.PlaceId,
            source.Price
        );
    SELECT SCOPE_IDENTITY()