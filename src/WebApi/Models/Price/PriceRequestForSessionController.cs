namespace WebApi.Models.Price
{
    public class PriceRequestForSessionController
    {
        public int[] PlaceId { get;}

        public decimal[] Price { get;}

        public PriceRequestForSessionController
        (
            int[] placeId,
            decimal[] price
        )
        {
            PlaceId = placeId;
            Price = price;
        }
    }
}
