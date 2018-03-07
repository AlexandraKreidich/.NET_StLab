using JetBrains.Annotations;

namespace BusinessLayer.Models
{
    public class HallModelForApi
    {
        public int Id { get;}

        public int CinemaId { get;}

        [NotNull]
        public string Name { get;}

        [NotNull]
        public PlaceModel[] Places { get;}

        [NotNull]
        public HallSchemeModel[] HallSchemeModels { get;}

        public HallModelForApi(
            int id,
            int cinemaId,
            [NotNull] string name,
            [NotNull] PlaceModel[] places,
            [NotNull] HallSchemeModel[] hallSchemeModel
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
