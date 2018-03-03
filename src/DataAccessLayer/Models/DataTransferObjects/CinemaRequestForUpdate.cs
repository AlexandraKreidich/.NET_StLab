using JetBrains.Annotations;

namespace DataAccessLayer.Models.DataTransferObjects
{
    public class CinemaRequestForUpdate : CinemaBase
    {
        public int Id { get; }

        public int HallsNumber { get; }

        public CinemaRequestForUpdate(
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
