using JetBrains.Annotations;

namespace BusinessLayer.Models
{
    [UsedImplicitly]
    public class PriceBlRequest
    {
        [NotNull]
        public int[] PlaceIds { get;}

        [NotNull]
        public decimal[] Prices { get;}

        public int SessionId { get;}

        public PriceBlRequest
        (
            [NotNull] int[] placeIds,
            [NotNull] decimal[] prices,
            int sessionId
        )
        {
            PlaceIds = placeIds;
            Prices = prices;
            SessionId = sessionId;
        }
    }
}
