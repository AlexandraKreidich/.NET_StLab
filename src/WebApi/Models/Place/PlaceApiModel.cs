using JetBrains.Annotations;

namespace WebApi.Models.Place
{
    [UsedImplicitly]
    public class PlaceApiModel
    {
        public int Id { get; }

        public int HallId { get; }

        [NotNull]
        public PlaceTypeApiModel Type { get; }

        public decimal Price { get; }

        public int RowNumber { get;}

        public int PlaceNumber { get;}

        [NotNull] public string PlaceStatus { get; }

        public PlaceApiModel(
            int id,
            int hallId,
            [NotNull] PlaceTypeApiModel type,
            decimal price,
            int rowNumber,
            int placeNumber,
            string placeStatus
        )
        {
            Id = id;
            HallId = hallId;
            Type = type;
            Price = price;
            RowNumber = rowNumber;
            PlaceNumber = placeNumber;
            PlaceStatus = placeStatus;
        }
    }
}
