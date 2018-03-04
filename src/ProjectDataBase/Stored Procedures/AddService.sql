CREATE PROCEDURE [dbo].[AddService]
    @Name NVARCHAR(50),
    @Price DECIMAL(10,4)
AS
    INSERT INTO [dbo].[Service]([Name], [Price])
    VALUES (
        @Name,
        @Price
    )
SELECT SCOPE_IDENTITY()
