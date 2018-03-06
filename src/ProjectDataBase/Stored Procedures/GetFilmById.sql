CREATE PROCEDURE [dbo].[GetFilmById]
    @Id int
AS
    SELECT 
        Film.Id,
        Film.Name,
        Film.Description,
        Film.StartRentDate,
        Film.EndRentDate
    from Film
    where Film.Id = @Id
