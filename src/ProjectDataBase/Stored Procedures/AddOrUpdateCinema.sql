CREATE PROCEDURE [dbo].[AddOrUpdateCinema]
    @Id INT,
    @Name NVARCHAR(50),
    @City NVARCHAR(50)
AS
    MERGE dbo.Cinema AS target
    USING (SELECT @Id, @Name, @City) AS source (Id, Name, City)
    ON (target.Id = source.Id)
    WHEN MATCHED THEN
        UPDATE SET
            Name = source.Name,
            City = source.City
    WHEN NOT MATCHED THEN
        INSERT (Name, City)
        VALUES (source.Name, source.City);
select SCOPE_IDENTITY()