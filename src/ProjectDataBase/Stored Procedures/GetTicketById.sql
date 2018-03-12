CREATE PROCEDURE [dbo].[GetTicketById]
    @Id INT
AS
    SELECT *
    FROM Ticket
    WHERE Id = @Id