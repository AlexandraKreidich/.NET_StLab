using JetBrains.Annotations;

namespace DataAccessLayer.Models.DataTransferObjects
{
    [UsedImplicitly]
    public class CinemaModel
    {
        public int Id { get; }

        public int HallsNumber { get; }

        [NotNull]
        public string Name { get; }

        [NotNull]
        public string City { get; }

        public CinemaModel(
            int id,
            [NotNull] string name,
            [NotNull] string city,
            int hallsNumber
        )
        {
            Id = id;
            HallsNumber = hallsNumber;
            Name = name;
            City = city;
        }
    }
}
