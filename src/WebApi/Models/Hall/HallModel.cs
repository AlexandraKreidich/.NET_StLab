using JetBrains.Annotations;

namespace WebApi.Models.Hall
{
    public class HallModel
    {
        public int Id { get;}

        public int CinemaId { get;}

        [NotNull]
        public string Name { get;}

        [CanBeNull]
        public Place.Place[] Places { get;}

        [CanBeNull]
        public HallSchemeModel[] HallSchemeModels { get;}

        public HallModel(
            int id,
            int cinemaId,
            [NotNull] string name,
            [CanBeNull] Place.Place[] places,
            [CanBeNull] HallSchemeModel[] hallSchemeModels
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
