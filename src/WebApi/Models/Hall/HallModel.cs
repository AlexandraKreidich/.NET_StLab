using JetBrains.Annotations;
using WebApi.Models.Place;

namespace WebApi.Models.Hall
{
    [UsedImplicitly]
    public class HallModel
    {
        public int Id { get; }

        public int CinemaId { get; }

        [NotNull]
        public string Name { get; }

        [CanBeNull]
        public PlaceModelForHall[] Places { get; }

        [CanBeNull]
        public HallSchemeModel[] HallSchemeModels { get; }

        public HallModel(
            int id,
            int cinemaId,
            [NotNull] string name,
            [CanBeNull] PlaceModelForHall[] places,
            [CanBeNull] HallSchemeModel[] hallSchemeModel
        )
        {
            Id = id;
            CinemaId = cinemaId;
            Name = name;
            Places = places;
            HallSchemeModels = hallSchemeModel;
        }
    }
}
