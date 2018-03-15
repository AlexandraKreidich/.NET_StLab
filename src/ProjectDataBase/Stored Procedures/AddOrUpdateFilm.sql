CREATE PROCEDURE [dbo].[AddOrUpdateFilm]
    @Id int,
    @Name nvarchar(50),
    @Description nvarchar(300),
    @StartRentDate datetimeoffset,
    @EndRentDate datetimeoffset
AS
    MERGE dbo.Film AS target
    USING
        (SELECT @Id, @Name, @Description, @StartRentDate, @EndRentDate)
    AS source
        (Id, Name, Description, StartRentDate, EndRentDate)
    ON (target.Id = source.Id)
    WHEN MATCHED THEN
        UPDATE SET
            Name = source.Name,
            Description = source.Description,
            StartRentDate = source.StartRentDate,
            EndRentDate = source.EndRentDate
    WHEN NOT MATCHED THEN
        INSERT (Name, Description, StartRentDate, EndRentDate)
        VALUES
        (
            source.Name,
            source.Description,
            source.StartRentDate,
            source.EndRentDate
        );
    select SCOPE_IDENTITY()