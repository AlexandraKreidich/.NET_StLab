CREATE PROCEDURE [dbo].[AddOrUpdateTicket]
    @UserId INT,
    @PriceId INT,
    @TicketStatus NVARCHAR(50)
AS
    DECLARE @CreatedAt DATETIMEOFFSET
    SET @CreatedAt = CONVERT(datetimeoffset, SYSDATETIMEOFFSET());
    IF(
        (SELECT Id
        FROM Ticket
        WHERE Ticket.PriceId = @PriceId) IS NULL
    )
        INSERT INTO [dbo].Ticket (PriceId, UserId, TicketStatusId, CreatedAt)
            VALUES
            (
                @PriceId,
                @UserId,
                (
                    SELECT TicketStatus.Id
                    FROM TicketStatus
                    WHERE TicketStatus.Name = @TicketStatus
                ),
                @CreatedAt
            )
    ELSE
        UPDATE Ticket
        SET
            UserId = @UserId,
            CreatedAt = @CreatedAt,
            TicketStatusId =
                (
                    SELECT TicketStatus.Id
                    FROM TicketStatus
                    WHERE TicketStatus.Name = @TicketStatus
                )
        WHERE PriceId = @PriceId
    SELECT Id
    FROM Ticket
    WHERE Ticket.PriceId = @PriceId