using JetBrains.Annotations;

namespace BusinessLayer.Models
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
