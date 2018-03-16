using Common;
using JetBrains.Annotations;

namespace BusinessLayer.Models
{
    public class TicketBlModelRequest
    {
        public int UserId { get; }

        public int PriceId { get; }

        [CanBeNull]
        public int[] Services { get; }

        public TicketBlModelRequest
        (
            int userId,
            int priceId,
            [CanBeNull] int[] services
        )
        {
            UserId = userId;
            PriceId = priceId;
            Services = services;
        }
    }
}
