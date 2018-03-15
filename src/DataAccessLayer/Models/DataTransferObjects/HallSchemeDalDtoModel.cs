using JetBrains.Annotations;

namespace DataAccessLayer.Models.DataTransferObjects
{
    [UsedImplicitly]
    public class HallSchemeDalDtoModel
    {
        public int Id { get; }

        public int HallId { get; }

        public int RowNumber { get; }

        public int PlacesCount { get; }

        public HallSchemeDalDtoModel(
            int id,
            int hallId,
            int rowNumber,
            int placesCount
        )
        {
            Id = id;
            HallId = hallId;
            RowNumber = rowNumber;
            PlacesCount = placesCount;
        }
    }
}
