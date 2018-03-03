CREATE PROCEDURE [dbo].[UpdateCinema]
    @Id int,
    @City nvarchar(50),
    @Name nvarchar(50)
AS
    UPDATE Cinema
        SET 
            City = @City, 
            [Name]= @Name
    WHERE Id = @Id;
