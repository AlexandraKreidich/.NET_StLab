using JetBrains.Annotations;
using PlaceModelResponse = WebApi.Models.Place.PlaceModelResponseForHall;

namespace WebApi.Models.Hall
{
    [UsedImplicitly]
    public class HallModelResponse
    {
        public int Id { get; }

        public int CinemaId { get; }

        [NotNull]
        public string Name { get; }

        [CanBeNull]
        public PlaceModelResponse[] Places { get; }

        [CanBeNull]
        public HallSchemeModelResponse[] HallSchemeModels { get; }

        public HallModelResponse(
            int id,
            int cinemaId,
            [NotNull] string name,
            [CanBeNull] PlaceModelResponse[] places,
            [CanBeNull] HallSchemeModelResponse[] hallSchemeModel
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
