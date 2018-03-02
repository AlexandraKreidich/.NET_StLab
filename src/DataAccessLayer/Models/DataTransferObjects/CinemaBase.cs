using JetBrains.Annotations;

namespace DataAccessLayer.Models.DataTransferObjects
{
    public class CinemaBase
    {
        [NotNull]
        public string Name { get; }

        [NotNull]
        public string City { get; }

        public CinemaBase(
            [NotNull] string name,
            [NotNull] string city
        )
        {
            Name = name;
            City = city;
        }
    }
}
