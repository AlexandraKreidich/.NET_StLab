using JetBrains.Annotations;
using WebApi.Models.Service;

namespace WebApi.Models.Ticket
{
    public class TicketApiModelRequest
    {
        public int PriceId { get; }

        [CanBeNull]
        public ServiceApiModelRequestForTicket[] Services { get; }

        public TicketApiModelRequest
        (
            int priceId,
            [CanBeNull] ServiceApiModelRequestForTicket[] services
        )
        {
            PriceId = priceId;
            Services = services;
        }
    }
}
