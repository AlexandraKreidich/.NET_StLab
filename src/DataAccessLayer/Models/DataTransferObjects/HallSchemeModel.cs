using JetBrains.Annotations;

namespace DataAccessLayer.Models.DataTransferObjects
{
    [UsedImplicitly]
    public class HallSchemeModel
    {

        public int Id { get; set; }

        public int HallId { get; set; }

        public int RowNumber { get; set; }

        public int PlacesCount { get; set; }

        public HallSchemeModel(
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
