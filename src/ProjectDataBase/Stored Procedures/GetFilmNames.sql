CREATE PROCEDURE [dbo].[GetFilmNames]
AS
    SELECT DISTINCT
        Film.Name as Name
    FROM
        Film
