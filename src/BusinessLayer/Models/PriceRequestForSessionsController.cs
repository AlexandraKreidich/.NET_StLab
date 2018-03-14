using JetBrains.Annotations;

namespace BusinessLayer.Models
{
    [UsedImplicitly]
    public class PriceRequestForSessionController
    {
        public int[] PlaceId { get; set; }

        public decimal[] Price { get; set; }

        public int SessionId { get; set; }

        public PriceRequestForSessionController
        (
            int[] placeId,
            decimal[] price,
            int sessionId
        )
        {
            PlaceId = placeId;
            Price = price;
            SessionId = sessionId;
        }
    }
}
