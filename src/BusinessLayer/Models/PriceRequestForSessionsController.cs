using JetBrains.Annotations;

namespace BusinessLayer.Models
{
    [UsedImplicitly]
    public class PriceRequestForSessionController
    {
        [NotNull]
        public int[] PlaceId { get;}

        [NotNull]
        public decimal[] Price { get;}

        public int SessionId { get;}

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
