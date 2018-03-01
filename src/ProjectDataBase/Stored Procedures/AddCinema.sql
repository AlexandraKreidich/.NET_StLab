CREATE PROCEDURE [dbo].[AddCinema]
    @Name NVARCHAR(50),
    @City NVARCHAR(50)
AS
   INSERT INTO [dbo].[Cinema] ([Name], City)
   VALUES(
        @Name,
        @City
   )
SELECT SCOPE_IDENTITY()