using JetBrains.Annotations;

namespace WebApi.Models.Cinema
{
    public class CinemaModelResponse : CinemaModelBase
    {
        public int Id { get;}

        public int HallsNumber { get; }

        public CinemaModelResponse(
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
