using JetBrains.Annotations;

namespace WebApi.Models.Ticket
{
    public class TicketApiModelRequest
    {
        public int PriceId { get; }

        [CanBeNull]
        public int[] Services { get; }

        public TicketApiModelRequest
        (
            int priceId,
            [CanBeNull] int[] services
        )
        {
            PriceId = priceId;
            Services = services;
        }
    }
}
