using JetBrains.Annotations;

namespace DataAccessLayer.Models.Entities
{
    [UsedImplicitly]
    internal class Place
    {
        public int Id { get; set; }

        public int HallId { get; set; }

        [NotNull]
        public string Type { get; set; }

        public int PlaceNumber { get; set; }

        public int RowNumber { get; set; }
    }
}
