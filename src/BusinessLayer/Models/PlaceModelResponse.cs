using JetBrains.Annotations;

namespace BusinessLayer.Models
{
    [UsedImplicitly]
    public class PlaceModelResponse
    {
        public int Id { get; }

        public int HallId { get; }

        [NotNull]
        public string Type { get; }

        public int RowNumber { get; }

        public int PlaceNumber { get; }

        public PlaceModelResponse(
            int id,
            int hallId,
            [NotNull] string type,
            int rowNumber,
            int placeNumber
        )
        {
            Id = id;
            HallId = hallId;
            Type = type;
            RowNumber = rowNumber;
            PlaceNumber = placeNumber;
        }
    }
}
