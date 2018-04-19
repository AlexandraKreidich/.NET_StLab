CREATE PROCEDURE [dbo].[AddOrUpdateTicket]
    @UserId INT,
    @PriceId INT,
    @TicketStatus NVARCHAR(50)
AS
    DECLARE
        @CreatedAt DATETIMEOFFSET,
        @DateNow datetimeoffset,
        @Interval int = 15
    SET @CreatedAt = CONVERT(datetimeoffset, SYSDATETIMEOFFSET());
    SET @DateNow = CONVERT(datetimeoffset, SYSDATETIMEOFFSET());
    IF(
        (
            (SELECT Id
            FROM Ticket
            WHERE Ticket.PriceId = @PriceId)
        IS NULL) OR
        (
            DATEDIFF(minute,(
                SELECT CreatedAt
                FROM Ticket
                WHERE Ticket.PriceId = @PriceId),
            @DateNow)
        < @Interval)
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
        BEGIN

        DELETE FROM
            TicketService
        WHERE
            TicketId = (
                SELECT Id
                FROM Ticket
                WHERE Ticket.PriceId = @PriceId
            )

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

        END;
    SELECT Id
    FROM Ticket
    WHERE Ticket.PriceId = @PriceId