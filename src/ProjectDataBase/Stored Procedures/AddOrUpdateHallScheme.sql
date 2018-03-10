CREATE PROCEDURE [dbo].[AddOrUpdateHallScheme]
    @Id int,
    @HallId int,
    @RowNumber int,
    @PlacesCount int
AS
    MERGE dbo.HallScheme AS target
    USING (SELECT @Id, @HallId, @RowNumber, @PlacesCount) AS source (Id, HallId, RowNumber, PlacesCount)
    ON (target.Id = source.Id)
    WHEN MATCHED THEN
        UPDATE SET
            RowNumber = source.RowNumber,
            PlacesCount = source.PlacesCount
    WHEN NOT MATCHED THEN
        INSERT (HallId, RowNumber, PlacesCount)
        VALUES (source.HallId, source.RowNumber, source.PlacesCount);
select SCOPE_IDENTITY()