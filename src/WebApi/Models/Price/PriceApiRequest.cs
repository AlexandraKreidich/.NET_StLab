using JetBrains.Annotations;

namespace WebApi.Models.Price
{
    public class PriceApiRequest
    {
        [NotNull]
        public int[] PlaceIds { get;}

        [NotNull]
        public decimal[] Prices { get;}

        public PriceApiRequest
        (
            [NotNull] int[] placeIds,
            [NotNull] decimal[] prices
        )
        {
            PlaceIds = placeIds;
            Prices = prices;
        }
    }
}
