using JetBrains.Annotations;
using WebApi.Models.Place;

namespace WebApi.Models.Hall
{
    [UsedImplicitly]
    public class HallApiModel
    {
        public int Id { get; }

        public int CinemaId { get; }

        [NotNull]
        public string Name { get; }

        [CanBeNull]
        public PlaceApiModel[] PlacesApi { get; }

        [CanBeNull]
        public HallSchemeApiModel[] HallSchemeApiModels { get; }

        public HallApiModel(
            int id,
            int cinemaId,
            [NotNull] string name,
            [CanBeNull] PlaceApiModel[] placesApi,
            [CanBeNull] HallSchemeApiModel[] hallSchemeApiModels
        )
        {
            Id = id;
            CinemaId = cinemaId;
            Name = name;
            PlacesApi = placesApi;
            HallSchemeApiModels = hallSchemeApiModels;
        }
    }
}
