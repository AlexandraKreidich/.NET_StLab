CREATE PROCEDURE [dbo].[GetCinemaCities]
AS
    SELECT DISTINCT
        Cinema.City as Name
    FROM
        Cinema
