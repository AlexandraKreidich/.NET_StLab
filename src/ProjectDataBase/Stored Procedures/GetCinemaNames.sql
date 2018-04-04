CREATE PROCEDURE [dbo].[GetCinemaNames]
AS
    SELECT DISTINCT
        Cinema.Name as Name
    FROM 
        Cinema
