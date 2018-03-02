using JetBrains.Annotations;

namespace DataAccessLayer.Models.DataTransferObjects
{
    [UsedImplicitly]
    public class HallSchemeResponse
    {

        public int Id { get; set; }

        public int HallId { get; set; }

        public int RowNumber { get; set; }

        public int PlacesCount { get; set; }

    }
}
