CREATE PROCEDURE [dbo].[AddOrUpdateService]
    @Id INT = 0,
    @Name NVARCHAR(50),
    @Price money
AS
    MERGE dbo.Service AS target
    USING (SELECT @Id, @Name, @Price) AS source (Id, Name, Price)
    ON (target.Id = source.Id)
    WHEN MATCHED THEN
        UPDATE SET
            Name = source.Name,
            Price = source.Price
    WHEN NOT MATCHED THEN
        INSERT (Name, Price)
        VALUES (source.Name, source.Price);
select SCOPE_IDENTITY()