using JetBrains.Annotations;

namespace BusinessLayer.Models
{
    public class CinemaModelRequestForUpdate : CinemaModelBase
    {
        public int Id { get; }

        public int HallsNumber { get; }

        public CinemaModelRequestForUpdate(
            int id,
            [NotNull] string name,
            [NotNull] string city,
            int hallsNumber
        )
            : base(name, city)
        {
            Id = id;
            HallsNumber = hallsNumber;
        }
    }
}
