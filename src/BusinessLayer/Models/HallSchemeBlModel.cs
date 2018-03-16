using JetBrains.Annotations;

namespace BusinessLayer.Models
{
    [UsedImplicitly]
    public class HallSchemeBlModel
    {
        public int Id { get;}

        public int HallId { get;}

        public int RowNumber { get;}

        public int PlacesCount { get;}

        public HallSchemeBlModel(
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
