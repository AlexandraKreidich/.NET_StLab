CREATE PROCEDURE [dbo].[AddOrUpdatePlace]
    @Id int,
    @HallId int,
    @PlaceTypeId int,
    @PlaceNumber int,
    @RowNumber int
AS
    MERGE dbo.Place AS target
    USING
        (SELECT @Id, @HallId, @PlaceTypeId, @PlaceNumber, @RowNumber)
    AS source
        (Id, HallId, PlaceTypeId, PlaceNumber, RowNumber)
    ON (target.Id = source.Id)
    WHEN MATCHED THEN
        UPDATE SET
            PlaceTypeId = source.PlaceTypeId,
            PlaceNumber = source.PlaceNumber,
            RowNumber = source.RowNumber
    WHEN NOT MATCHED THEN
        INSERT (HallId, PlaceTypeId, PlaceNumber, RowNumber)
        VALUES
        (
            source.HallId,
            source.PlaceTypeId,
            source.PlaceNumber,
            source.RowNumber);
    select SCOPE_IDENTITY()