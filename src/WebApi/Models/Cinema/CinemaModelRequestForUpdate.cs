using JetBrains.Annotations;

namespace WebApi.Models.Cinema
{
    public class CinemaModelRequestForUpdate : CinemaModelBase
    {
        public int HallsNumber { get; }
        
        public CinemaModelRequestForUpdate(
            [NotNull] string name,
            [NotNull] string city,
            int hallsNumber
        )
            : base(name, city)
        {
            HallsNumber = hallsNumber;
        }
    }
}
