using JetBrains.Annotations;

namespace BusinessLayer.Models
{
    public class HallModelResponse
    {
        public int Id { get;}

        public int CinemaId { get;}

        [NotNull]
        public string Name { get;}

        [NotNull]
        public PlaceModelResponse[] Places { get;}

        [NotNull]
        public HallSchemeModelResponse[] HallSchemeModels { get;}

        public HallModelResponse(
            int id,
            int cinemaId,
            [NotNull] string name,
            [NotNull] PlaceModelResponse[] places,
            [NotNull] HallSchemeModelResponse[] hallSchemeModel
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
