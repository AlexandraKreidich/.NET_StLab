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

        public PlaceDalDtoModel(
            int id,
            int hallId,
            [NotNull] string type,
            int typeId,
            int placeNumber,
            int rowNumber
        )
        {
            Id = id;
            HallId = hallId;
            Type = type;
            TypeId = typeId;
            PlaceNumber = placeNumber;
            RowNumber = rowNumber;
        }
    }
}
