CREATE PROCEDURE [dbo].[ClearBookedTickets]
AS
    DECLARE
        @DateNow DATETIMEOFFSET,
        @Interval int
    SET @DateNow = CONVERT(datetimeoffset, SYSDATETIMEOFFSET());
    SET @Interval = 15;
    DELETE from
        [dbo].Ticket
    WHERE (
            (DATEDIFF(minute, Ticket.CreatedAt, @DateNow) > @Interval)
            AND (
                    (
                        SELECT TicketStatus.Name
                        FROM TicketStatus
                        WHERE Ticket.TicketStatusId = TicketStatus.Id
                    ) = 'InProcess'
                )
        )