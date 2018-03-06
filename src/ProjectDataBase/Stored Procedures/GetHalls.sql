CREATE PROCEDURE [dbo].[GetHalls]
    @CinemaId int
AS
    SELECT *
    FROM [Hall]
    WHERE CinemaId = @CinemaId
