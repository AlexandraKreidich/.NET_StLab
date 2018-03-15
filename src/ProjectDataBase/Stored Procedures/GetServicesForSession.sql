CREATE PROCEDURE [dbo].[GetServicesForSession]
    @SessionId int
AS
    SELECT
        [Id],
        [Name],
        [Price]
    FROM [Service]
    JOIN SessionService ON SessionService.ServiceId = Service.Id
    WHERE SessionService.SessionId = @SessionId