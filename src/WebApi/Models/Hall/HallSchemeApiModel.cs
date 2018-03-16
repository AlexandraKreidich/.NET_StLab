using JetBrains.Annotations;

namespace WebApi.Models.Hall
{
    [UsedImplicitly]
    public class HallSchemeApiModel
    {
        public int Id { get; }

        public int HallId { get;}

        public int RowNumber { get; }

        public int PlacesCount { get; }

        public HallSchemeApiModel(
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
