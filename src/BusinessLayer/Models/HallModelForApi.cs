using JetBrains.Annotations;

namespace BusinessLayer.Models
{
    public class HallModelForApi
    {
        public int Id { get;}

        public int CinemaId { get;}

        [NotNull]
        public string Name { get;}

        [CanBeNull]
        public PlaceModel[] Places { get;}

        [CanBeNull]
        public HallSchemeModel[] HallSchemeModels { get;}

        public HallModelForApi(
            int id,
            int cinemaId,
            [NotNull] string name,
            [CanBeNull] PlaceModel[] places,
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
