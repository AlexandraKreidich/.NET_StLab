using JetBrains.Annotations;

namespace DataAccessLayer.Models.DataTransferObjects
{
    [UsedImplicitly]
    public class PlaceDalDtoModel
    {
        public int Id { get;}

        public int HallId { get;}

        [NotNull]
        public string Type { get;}

        public int TypeId { get; }

        public int PlaceNumber { get;}

        public int RowNumber { get;}

        public decimal Price { get; }

        public string PlaceStatus { get; }

        public PlaceDalDtoModel(
            int id,
            int hallId,
            [NotNull] string type,
            int typeId,
            int placeNumber,
            int rowNumber,
            decimal price,
            [NotNull] string placeStatus
        )
        {
            Id = id;
            HallId = hallId;
            Type = type;
            TypeId = typeId;
            PlaceNumber = placeNumber;
            RowNumber = rowNumber;
            Price = price;
            PlaceStatus = placeStatus;
        }
    }
}
