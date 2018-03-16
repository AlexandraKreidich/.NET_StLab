CREATE PROCEDURE [dbo].[DeleteTicket]
    @Id INT
AS
    DELETE FROM [dbo].Ticket
    WHERE Id = @Id
