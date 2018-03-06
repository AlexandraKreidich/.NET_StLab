CREATE PROCEDURE [dbo].[GetNowPlayingFilms]
    @param1 int = 0,
    @param2 int
AS
    DECLARE @dt datetimeoffset = CONVERT(datetimeoffset, GETDATE())
    SELECT * FROM [Film]    
    WHERE @dt between StartRentDate and EndRentDate OPTION (RECOMPILE)