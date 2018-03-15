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

        [NotNull]
        public PlaceModelForHall[] Places { get; }

        [NotNull]
        public HallSchemeModel[] HallSchemeModels { get; }

        public HallModel(
            int id,
            int cinemaId,
            [NotNull] string name,
            [NotNull] PlaceModelForHall[] places,
            [NotNull] HallSchemeModel[] hallSchemeModels
        )
        {
            Id = id;
            CinemaId = cinemaId;
            Name = name;
            Places = places;
            HallSchemeModels = hallSchemeModels;
        }
    }
}
