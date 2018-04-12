CREATE PROCEDURE [dbo].[AddTicket]
    @UserId INT,
    @PriceId INT,
    @TicketStatus NVARCHAR(50)
AS
    DECLARE @CreatedAt DATETIMEOFFSET
    SET @CreatedAt = CONVERT(datetimeoffset, SYSDATETIMEOFFSET());
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
    SELECT SCOPE_IDENTITY()