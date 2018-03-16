using JetBrains.Annotations;

namespace BusinessLayer.Models
{
    public class FullHallBlModel
    {
        public int Id { get; }

        public int CinemaId { get; }

        [NotNull]
        public string Name { get; }

        [CanBeNull]
        public PlaceBlModel[] PlacesBl { get; }

        [CanBeNull]
        public HallSchemeBlModel[] HallSchemeBlModels { get; }

        public FullHallBlModel(
            int id,
            int cinemaId,
            [NotNull] string name,
            [CanBeNull] PlaceBlModel[] placesBl,
            [CanBeNull] HallSchemeBlModel[] hallSchemeBlModel
        )
        {
            Id = id;
            CinemaId = cinemaId;
            Name = name;
            PlacesBl = placesBl;
            HallSchemeBlModels = hallSchemeBlModel;
        }
    }
}
