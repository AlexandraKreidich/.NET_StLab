CREATE PROCEDURE [dbo].[GetHallById]
    @Id int
AS
    SELECT *
    FROM Hall
    WHERE Hall.Id = @Id
