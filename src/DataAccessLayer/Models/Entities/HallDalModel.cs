using JetBrains.Annotations;

namespace DataAccessLayer.Models.Entities
{
    [UsedImplicitly]
    internal class HallDalModel
    {
        public int Id { get; set; }

        public int CinemaId { get; set; }

        [NotNull]
        public string HallName { get; }

        [NotNull]
        public string CinemaName { get; }
    }
}
