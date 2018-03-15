using Common;
using JetBrains.Annotations;

namespace WebApi.Models.Ticket
{
    public class TicketApiModelRequest
    {
        public int PriceId { get; }

        [CanBeNull]
        public int[] Services { get; }

        public TicketStatus Status { get; }

        public TicketApiModelRequest
        (
            int priceId,
            [CanBeNull] int[] services,
            TicketStatus status
        )
        {
            PriceId = priceId;
            Services = services;
            Status = status;
        }
    }
}
