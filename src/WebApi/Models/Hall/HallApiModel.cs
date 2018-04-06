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
        public string HallName { get; }

        [NotNull]
        public string CinemaName { get; }

        [CanBeNull]
        public PlaceApiModel[] PlacesApi { get; }

        [CanBeNull]
        public HallSchemeApiModel[] HallSchemeApiModels { get; }

        public HallApiModel(
            int id,
            int cinemaId,
            [NotNull] string hallName,
            [NotNull] string cinemaName,
            [CanBeNull] PlaceApiModel[] placesApi,
            [CanBeNull] HallSchemeApiModel[] hallSchemeApiModels
        )
        {
            Id = id;
            CinemaId = cinemaId;
            HallName = hallName;
            CinemaName = cinemaName;
            PlacesApi = placesApi;
            HallSchemeApiModels = hallSchemeApiModels;
        }
    }
}
