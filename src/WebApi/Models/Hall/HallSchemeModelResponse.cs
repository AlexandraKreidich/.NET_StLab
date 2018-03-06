using JetBrains.Annotations;

namespace WebApi.Models.Hall
{
    [UsedImplicitly]
    public class HallSchemeModelResponse
    {
        public int Id { get; }

        public int HallId { get;}

        public int RowNumber { get; }

        public int PlacesCount { get; }

        public HallSchemeModelResponse(
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
