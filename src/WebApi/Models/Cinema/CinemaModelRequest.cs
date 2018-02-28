using JetBrains.Annotations;

namespace WebApi.Models.Cinema
{
    public class CinemaModelRequest : CinemaModelBase
    {
        public CinemaModelRequest(
            [NotNull] string name,
            [NotNull] string city
        )
            : base(name, city)
        {
        }
    }
}
