using JetBrains.Annotations;

namespace BusinessLayer.Models
{
    public class CinemaModelBase
    {
        [NotNull]
        public string Name { get; }

        [NotNull]
        public string City { get; }

        public CinemaModelBase(
            [NotNull] string name,
            [NotNull] string city
        )
        {
            Name = name;
            City = city;
        }
    }
}
