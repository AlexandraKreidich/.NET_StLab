using JetBrains.Annotations;

namespace BusinessLayer.Models
{
    [UsedImplicitly]
    internal class HallBlModel
    {
        public int Id { get; }

        public int CinemaId { get; }

        [NotNull]
        public string HallName { get; }

        [NotNull]
        public string CinemaName { get; }

        public HallBlModel(
            int id,
            int cinemaId,
            [NotNull] string hallName,
            [NotNull] string cinemaName
        )
        {
            Id = id;
            CinemaId = cinemaId;
            HallName = hallName;
            CinemaName = cinemaName;
        }
    }
}
