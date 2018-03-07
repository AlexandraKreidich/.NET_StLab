CREATE PROCEDURE [dbo].[DeleteFilm]
    @Id int
AS
    DELETE FROM Film
    WHERE Id = @Id
