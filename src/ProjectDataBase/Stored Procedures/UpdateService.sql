CREATE PROCEDURE [dbo].[UpdateService]
    @Id int,
    @Name nvarchar(50),
    @Price money
AS
    update [Service]
        set
            [Name] = @Name,
            [Price] = @Price
        where Id = @Id
