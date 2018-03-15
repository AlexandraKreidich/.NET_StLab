CREATE PROCEDURE [dbo].[DeleteServicesFromSession]
    @SessionId int
AS
    DELETE FROM SessionService
    WHERE SessionId = @SessionId