using JetBrains.Annotations;

namespace BusinessLayer.Models
{
    [UsedImplicitly]
    public class PlaceBlModel
    {
        public int Id { get; }

        public int HallId { get; }

        [NotNull]
        public PlaceTypeBlModel Type { get; }

        public int RowNumber { get; }

        public int PlaceNumber { get; }

        public decimal Price { get; }

        [NotNull] public string PlaceStatus { get; }

        public PlaceBlModel(
            int id,
            int hallId,
            [NotNull] PlaceTypeBlModel type,
            int rowNumber,
            int placeNumber,
            decimal price,
            [NotNull] string placeStatus
        )
        {
            Id = id;
            HallId = hallId;
            Type = type;
            RowNumber = rowNumber;
            PlaceNumber = placeNumber;
            Price = price;
            PlaceStatus = placeStatus;
        }
    }
}
