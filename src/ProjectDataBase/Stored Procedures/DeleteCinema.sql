CREATE PROCEDURE [dbo].[DeleteCinema]
    @Id INT,
    @Result INT = 1
AS
    BEGIN TRY
        DELETE FROM [dbo].[Cinema]
        WHERE Id = @Id
        IF @@ROWCOUNT <>1
        SET @Result = 0
    END TRY
    BEGIN CATCH
        SET @Result = 0
    END CATCH
SELECT @Result