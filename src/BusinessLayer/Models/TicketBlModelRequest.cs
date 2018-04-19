using JetBrains.Annotations;

namespace BusinessLayer.Models
{
    public class TicketBlModelRequest
    {
        public int UserId { get; }

        public int PriceId { get; }

        [CanBeNull]
        public ServiceBlModelRequestForTicket[] Services { get; }

        public TicketBlModelRequest
        (
            int userId,
            int priceId,
            [CanBeNull] ServiceBlModelRequestForTicket[] services
        )
        {
            UserId = userId;
            PriceId = priceId;
            Services = services;
        }
    }
}
