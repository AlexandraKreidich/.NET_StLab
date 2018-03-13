CREATE PROCEDURE [dbo].[AddServiceForSession]
    @SessionId int,
    @ServiceId int
AS
    INSERT INTO SessionService(SessionId, ServiceId)
    VALUES (@SessionId, @ServiceId)
SELECT SCOPE_IDENTITY();
