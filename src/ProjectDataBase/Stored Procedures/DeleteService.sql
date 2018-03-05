CREATE PROCEDURE [dbo].[DeleteService]
    @Id INT
AS
    DELETE FROM Service
    WHERE Id = @Id