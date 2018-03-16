using Common;
using JetBrains.Annotations;

namespace DataAccessLayer.Models.DataTransferObjects
{
    [UsedImplicitly]
    public class TicketDalDtoModelRequest
    {
        public int UserId { get; }

        public int PriceId { get; }

        public TicketDalDtoModelRequest
        (
            int userId,
            int priceId
        )
        {
            UserId = userId;
            PriceId = priceId;
        }
    }
}
