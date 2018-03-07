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
    }
}
