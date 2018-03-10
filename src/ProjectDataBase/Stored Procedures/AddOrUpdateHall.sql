CREATE PROCEDURE [dbo].[AddOrUpdateHall]
    @Id int,
    @CinemaId int,
    @Name nvarchar(50)
AS
    MERGE dbo.Hall AS target
    USING (SELECT @Id, @CinemaId, @Name) AS source (Id, CinemaId, Name)
    ON (target.Id = source.Id)
    WHEN MATCHED THEN
        UPDATE SET
            CinemaId = source.CinemaId,
            Name = source.Name
    WHEN NOT MATCHED THEN
        INSERT (CinemaId, Name)
        VALUES (source.CinemaId, source.Name);
select SCOPE_IDENTITY()
