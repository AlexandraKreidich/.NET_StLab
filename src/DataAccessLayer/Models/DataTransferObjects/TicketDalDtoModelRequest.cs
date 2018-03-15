using Common;
using JetBrains.Annotations;

namespace DataAccessLayer.Models.DataTransferObjects
{
    [UsedImplicitly]
    public class TicketDalDtoModelRequest
    {
        public int UserId { get; }

        public int PriceId { get; }

        public TicketStatus Status { get; }

        public TicketDalDtoModelRequest
        (
            int userId,
            int priceId,
            TicketStatus status
        )
        {
            UserId = userId;
            PriceId = priceId;
            Status = status;
        }
    }
}
