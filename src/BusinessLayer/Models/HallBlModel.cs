using JetBrains.Annotations;

namespace BusinessLayer.Models
{
    [UsedImplicitly]
    internal class HallBlModel
    {
        public int Id { get; }

        public int CinemaId { get; }

        [NotNull]
        public string Name { get; }

        public HallBlModel(
            int id,
            int cinemaId,
            [NotNull] string name
        )
        {
            Id = id;
            CinemaId = cinemaId;
            Name = name;
        }
    }
}
