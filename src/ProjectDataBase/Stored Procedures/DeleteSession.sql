CREATE PROCEDURE [dbo].[DeleteSession]
    @Id int
AS
    DELETE FROM Session
    WHERE Id = @Id
SELECT @Id