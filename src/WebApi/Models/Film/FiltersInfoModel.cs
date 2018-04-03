using JetBrains.Annotations;

namespace WebApi.Models.Film
{
    public class FiltersInfoModel
    {
        [NotNull]
        public string[] FilmNames;

        [NotNull]
        public string[] CinemaNames;

        [NotNull]
        public string[] CityNames;

        public FiltersInfoModel(
            [NotNull] string[] filmNames,
            [NotNull] string[] cinemaNames,
            [NotNull] string[] cityNames
        )
        {
            FilmNames = filmNames;
            CityNames = cityNames;
            CinemaNames = cinemaNames;
        }
    }
}
