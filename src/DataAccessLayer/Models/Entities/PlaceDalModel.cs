using JetBrains.Annotations;

namespace DataAccessLayer.Models.Entities
{
    [UsedImplicitly]
    internal class PlaceDalModel
    {
        public int Id { get; set; }

        public int HallId { get; set; }

        [NotNull]
        public string Type { get; set; }

        public int TypeId { get; set; }

        public int PlaceNumber { get; set; }

        public int RowNumber { get; set; }
    }
}
