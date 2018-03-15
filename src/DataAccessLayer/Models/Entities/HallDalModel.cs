using JetBrains.Annotations;

namespace DataAccessLayer.Models.Entities
{
    [UsedImplicitly]
    internal class HallDalModel
    {
        public int Id { get; set; }

        public int CinemaId { get; set; }

        [NotNull]
        public string Name { get; set; }
    }
}
