CREATE PROCEDURE [dbo].[AddOrUpdateSession]
    @Id int = 0,
    @FilmId int,
    @HallId int,
    @Date datetimeoffset
AS
    MERGE dbo.Session AS target
    USING (SELECT @Id, @FilmId, @HallId, @Date) AS source (Id, FilmId, HallId, Date)
    ON (target.Id = source.Id)
    WHEN MATCHED THEN
        UPDATE SET
            FilmId = source.FilmId,
            HallId = source.HallId,
            Date = source.Date
    WHEN NOT MATCHED THEN
        INSERT (FilmId, HallId, Date)
        VALUES (source.FilmId, source.HallId, source.Date);
select SCOPE_IDENTITY()
