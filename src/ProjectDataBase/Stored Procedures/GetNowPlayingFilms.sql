CREATE PROCEDURE [dbo].[GetNowPlayingFilms]
AS
    DECLARE @dt datetimeoffset = CONVERT(datetimeoffset, GETDATE())
    SELECT *
    FROM [Film]
    WHERE @dt < EndRentDate