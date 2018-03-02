using JetBrains.Annotations;

namespace DataAccessLayer.Models.DataTransferObjects
{
    public class CinemaRequest : CinemaBase
    {
        public CinemaRequest(
            [NotNull] string name,
            [NotNull] string city
        )
            : base(name, city)
        {
        }
    }
}
