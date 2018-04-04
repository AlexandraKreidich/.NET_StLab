using JetBrains.Annotations;

namespace BusinessLayer.Models
{
    public class FiltersInfoBlModel
    {
        [NotNull]
        public string[] FilmNames;

        [NotNull]
        public string[] CinemaNames;

        [NotNull]
        public string[] CityNames;

        public FiltersInfoBlModel(
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
