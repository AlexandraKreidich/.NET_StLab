CREATE PROCEDURE [dbo].[AddOrUpdatePlace]
    @Id int,
    @HallId int,
    @PlaceType nvarchar(50),
    @PlaceNumber int,
    @RowNumber int
AS
    MERGE dbo.Place AS target
    USING
        (SELECT @Id, @HallId, @PlaceType, @PlaceNumber, @RowNumber)
    AS source
        (Id, HallId, PlaceType, PlaceNumber, RowNumber)
    ON (target.Id = source.Id)
    WHEN MATCHED THEN
        UPDATE SET
            PlaceTypeId = (
                SELECT Id FROM [dbo].PlaceType
                WHERE [Name] = @PlaceType
            ),
            PlaceNumber = source.PlaceNumber,
            RowNumber = source.RowNumber
    WHEN NOT MATCHED THEN
        INSERT (HallId, PlaceTypeId, PlaceNumber, RowNumber)
        VALUES
        (
            source.HallId,
            (
               SELECT Id FROM [dbo].PlaceType
               WHERE [Name] = @PlaceType
            ),
            source.PlaceNumber,
            source.RowNumber);
    select SCOPE_IDENTITY()