using JetBrains.Annotations;

namespace BusinessLayer.Models
{
    public class FullHallBlModel
    {
        public int Id { get; }

        public int CinemaId { get; }

        [NotNull]
        public string HallName { get; }

        [NotNull]
        public string CinemaName { get; }

        [CanBeNull]
        public PlaceBlModel[] PlacesBl { get; }

        [CanBeNull]
        public HallSchemeBlModel[] HallSchemeBlModels { get; }

        public FullHallBlModel(
            int id,
            int cinemaId,
            [NotNull] string hallName,
            [NotNull] string cinemaName,
            [CanBeNull] PlaceBlModel[] placesBl,
            [CanBeNull] HallSchemeBlModel[] hallSchemeBlModel
        )
        {
            Id = id;
            CinemaId = cinemaId;
            HallName = hallName;
            CinemaName = cinemaName;
            PlacesBl = placesBl;
            HallSchemeBlModels = hallSchemeBlModel;
        }
    }
}
